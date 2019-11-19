using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.WebAPI.Services
{
    public interface IUserService
    {
        Model.User GetById(int id);
        Model.User Authenticate(string email, string pass);
        Model.User GetCurrentUser();
    }
}
