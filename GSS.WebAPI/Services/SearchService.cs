﻿using AutoMapper;
using GSS.Database;
using GSS.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.WebAPI.Services
{
    public class SearchService : ISearchService
    {
        private readonly GSSContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public SearchService(GSSContext context, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _context = context;
        }
        //public List<Model.Search> Get(SearchesearchRequest request)
        //{
        //    var query = _context.Searches.AsQueryable();
        //    if (!string.IsNullOrWhiteSpace(request?.Name))
        //    {
        //        query = query.Where(x => x.Name.Contains(request.Name));
        //    }
        //    query = query.Include(x => x.Country);
        //    var list = query.ToList();
        //    return _mapper.Map<List<Model.Search>>(list);
        //}

        public Model.Search Insert(Model.Search request)
        {
            Delete(request.Name);

            var UserId = _userService.GetCurrentUser().Id;

            List<Model.Consensus> ConsensusList = new List<Model.Consensus>();
            foreach (var zone in request.Zones)
            {
                int i = 0;
                foreach (var consensus in zone.Consensus)
                {
                    consensus.Zone = zone;
                    var manager = request.Managers[i++];
                    if (manager.Id != 0)
                        consensus.ManagerId = manager.Id;
                    else
                        consensus.Manager = manager;

                    ConsensusList.Add(consensus);
                }
                zone.Consensus = null;
            }

            request.Id = 0;
            request.Active = true;

            var entity = _mapper.Map<Database.Search>(request);
            entity.UserId = UserId;
            _context.Searches.Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            // Create managers if missing
            foreach (var consensus in ConsensusList)
            {
                if (consensus.ManagerId == 0)
                {
                    if (string.IsNullOrEmpty(consensus.ManagerName))
                        continue;

                    var temp_manager = _context.Managers.Where(x => x.UserId == UserId)
                        .Where(x => x.Name == consensus.ManagerName)
                        .FirstOrDefault();

                    if (temp_manager != null)
                    {
                        consensus.ManagerId = temp_manager.Id;
                    }
                    else
                    {
                        var new_manager = new Manager
                        {
                            UserId = UserId,
                            Active = true,
                            Name = consensus.ManagerName
                        };
                        _context.Managers.Add(new_manager);
                        _context.SaveChanges();

                        consensus.ManagerId = new_manager.Id;
                    }
                }
            }

            foreach (var consensus in ConsensusList)
            {
                var Zone = entity.Zones.Where(x => x.Name == consensus.Zone.Name).FirstOrDefault();
                if (Zone == null)
                    continue;
                if (consensus.ManagerId == 0)
                    continue;

                var new_consensus = new Database.Consensus
                {
                    ManagerId = consensus.ManagerId,
                    ZoneId = Zone.Id,
                    Value = consensus.Value
                };

                _context.Consensus.Add(new_consensus);

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return _mapper.Map<Model.Search>(entity);
        }
        //public Model.Search GetById(int id)
        //{
        //    var entity = _context.Searches.Include(x => x.Country).Where(x => x.SearchId == id).FirstOrDefault();
        //    return _mapper.Map<Model.Search>(entity);
        //}
        public bool Delete(string name)
        {
            var entities = _context.Searches.Where(x => x.Name == name && x.UserId == _userService.GetCurrentUser().Id)
                .OrderBy(x => x.Id)
                .Include("Zones.Consensus")
                .Include("Zones.Segments.SegmentHistory")
                .ToList();
            if (entities.Count == 0)
                return false;

            foreach (var entity in entities)
            {
                _context.Searches.Remove(entity);
                foreach (var zone in entity.Zones)
                {
                    foreach (var segment in zone.Segments)
                    {
                        _context.Segments.Remove(segment);
                    }
                }

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }


            return true;
        }

        public bool Backup(IFormFile backup, string name)
        {
            var existingBackup = _context.SearchBackups.Where(x => x.Name == name && x.UserId == _userService.GetCurrentUser().Id)
             .FirstOrDefault();

            var stream = new MemoryStream();
            backup.CopyTo(stream);

            if (existingBackup != null)
            {
                existingBackup.DateModified = DateTime.Now;

                existingBackup.Backup = stream.ToArray();
            }
            else
            {
                var newBackup = new Database.SearchBackup
                {
                    DateModified = DateTime.Now,
                    UserId = _userService.GetCurrentUser().Id,
                    Name = name,
                    Backup = stream.ToArray()
                };
                _context.SearchBackups.Add(newBackup);
            }
            _context.SaveChanges();

            return true;
        }

        public List<Model.SearchBackup> GetAllBackups()
        {
            return _context.SearchBackups.Where(x => x.UserId == _userService.GetCurrentUser().Id && _context.Searches.Any(y => y.Name == x.Name && y.UserId == x.UserId && y.Active)).Select(
                x => new Model.SearchBackup
                {
                    Id = x.Id,
                    DateModified = x.DateModified,
                    Name = x.Name,
                    UserId = x.UserId,
                    Backup = null
                })
                .ToList();
        }

        public byte[] GetBackup(string name)
        {
            var existingBackup = _context.SearchBackups.Where(x => x.Name == name && x.UserId == _userService.GetCurrentUser().Id)
             .FirstOrDefault();
            if (existingBackup == null)
                throw new FileNotFoundException();

            return existingBackup.Backup;
        }

        public Model.Search Update(string name, SearchUpdateRequest request)
        {
            var search = _context.Searches.Where(x => x.Name == name).FirstOrDefault();

            _mapper.Map(request, search);

            _context.SaveChanges();
            return _mapper.Map<Model.Search>(search);
        }
    }
}
