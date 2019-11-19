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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        public Model.User GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet("GetCurrentUser")]
        [Authorize]
        public Model.User GetCurrentUser()
        {
            return _service.GetCurrentUser();
        }
    }
}