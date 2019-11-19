using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.User, Model.User>();
            CreateMap<Database.City, Model.City>();
            CreateMap<Database.Country, Model.Country>();
        }
    }
}
