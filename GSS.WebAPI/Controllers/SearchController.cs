﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GSS.Model.Requests;
using GSS.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GSS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _service;
        public SearchController(ISearchService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public List<Model.Search> Get([FromQuery]SearchSearchRequest request)
        //{
        //    return _service.Get(request);
        //}
        //[HttpGet("{id}")]
        //public Model.Search GetById(int id)
        //{
        //    return _service.GetById(id);
        //}
        
        [HttpPut("{name}")]
        [Authorize(Roles = "User")]
        public Model.Search Update(string name, [FromBody] SearchUpdateRequest request)
        {
            return _service.Update(name, request);
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public Model.Search Insert([FromBody] Model.Search request)
        {
            return _service.Insert(request);
        }

        [HttpDelete("{name}")]
        [Authorize(Roles = "User")]
        public bool Delete(string name)
        {
            return _service.Delete(name);
        }

        [HttpPost("Backup/{Name}")]
        [Authorize(Roles = "User")]
        public bool Backup(IFormFile Backup, string Name, DateTime LastModified)
        {
            return _service.Backup(Backup, Name);
        }

        [HttpGet("Backup")]
        [Authorize(Roles = "User")]
        public List<Model.SearchBackup> GetAllBackups()
        {
            return _service.GetAllBackups();
        }

        [HttpGet("Backup/{Name}")]
        [Authorize(Roles = "User")]
        public IActionResult GetBackup(string Name)
        {
            try
            {
                byte[] file = _service.GetBackup(Name);
                return File(file, "application/octet-stream", Name + ".bin");
            }
            catch (FileNotFoundException)
            {
                return new NotFoundResult();
            }

        }
    }
}