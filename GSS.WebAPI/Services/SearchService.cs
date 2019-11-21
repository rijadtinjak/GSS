using AutoMapper;
using GSS.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            List<Model.Consensus> ConsensusList = new List<Model.Consensus>();
            foreach (var zone in request.Zones)
            {
                int i = 0;
                foreach (var consensus in zone.Consensus)
                {
                    consensus.Zone = zone;
                    consensus.Manager = request.Managers[i++];
                    ConsensusList.Add(consensus);
                }
                zone.Consensus = null;
            }

            request.Id = 0;

            var entity = _mapper.Map<Database.Search>(request);
            entity.UserId = _userService.GetCurrentUser().Id;
            _context.Searches.Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            foreach (var consensus in ConsensusList)
            {
                int ZoneId = 0, ManagerId = 0;
                foreach (var zone in entity.Zones)
                {
                    if (zone.Name == consensus.Zone.Name)
                        ZoneId = zone.Id;
                }

                foreach (var manager in entity.Managers)
                {
                    if (manager.Name == consensus.Manager.Name)
                        ManagerId = manager.Id;
                }

                if (ZoneId != 0 && ManagerId != 0)
                {
                    _context.Consensus.Add(new Consensus
                    {
                        ManagerId = ManagerId,
                        ZoneId = ZoneId,
                        Value = consensus.Value
                    });

                }

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
    }
}
