using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSS.Model;

namespace GSS.WebAPI.Services
{
    public interface ISearchService
    {
        //List<Model.Search> Get(SearchSearchRequest request);
        //Model.Search GetById(int id);
        Model.Search Insert(Model.Search request);
        bool Delete(string name);
        //Model.Search Update(int id, SearchInsertRequest request);
    }
}
