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
    public class UserService : IUserService
    {
        private readonly GSSContext _context;
        private readonly IMapper _mapper;

        Model.User LoggedInUser { get; set; }

        public UserService(GSSContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public Model.User GetById(int id)
        {
            var query = _context.Users.Where(x => x.Id == id);
            query = query.Include(x => x.City.Country);
            var entity = query.FirstOrDefault();
            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Authenticate(string email, string pass)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(pass, user.Password))
                {
                    LoggedInUser = _mapper.Map<Model.User>(user);
                    return LoggedInUser;
                }
            }
            return null;
        }

        public Model.User GetCurrentUser()
        {
            var query = _context.Users.Where(x => x.Id == LoggedInUser.Id);
            query = query.Include(x => x.City.Country);
            var entity = query.FirstOrDefault();
            return _mapper.Map<Model.User>(entity);
        }

        public static string GenerateHash(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return passwordHash;
        }

    }
}
