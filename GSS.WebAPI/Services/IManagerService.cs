using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.WebAPI.Services
{
    public interface IManagerService
    {
        List<Model.Manager> Get();
    }
}
