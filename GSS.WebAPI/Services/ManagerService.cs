using AutoMapper;
using GSS.Database;
using GSS.WebAPI.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GSS.WebAPI.Services
{
    public class ManagerService : IManagerService
    {
        private readonly GSSContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ManagerService(GSSContext context, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _context = context;
        }
        public List<Model.Manager> Get()
        {
            var user_id = _userService.GetCurrentUser().Id;

            var list = _context.Managers.Where(x => x.UserId == user_id).ToList();
            return _mapper.Map<List<Model.Manager>>(list);
        }



    }
}
