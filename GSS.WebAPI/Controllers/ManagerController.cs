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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _service;
        public ManagerController(IManagerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public List<Model.Manager> Get()
        {
            return _service.Get();
        }
    }
}