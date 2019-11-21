using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //[HttpPut("{id}")]
        //[Authorize(Roles = "User")]

        //public Model.Search Update(int id, [FromBody] SearchInsertRequest request)
        //{
        //    return _service.Update(id, request);
        //}
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
    }
}