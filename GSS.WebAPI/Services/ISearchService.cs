using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSS.Model;
using GSS.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GSS.WebAPI.Services
{
    public interface ISearchService
    {
        //List<Model.Search> Get(SearchSearchRequest request);
        //Model.Search GetById(int id);
        Model.Search Insert(Model.Search request);
        bool Delete(string name);
        bool Backup(IFormFile backup, string name);
        List<SearchBackup> GetAllBackups();
        byte[] GetBackup(string name);
        Model.Search Update(string name, SearchUpdateRequest request);
    }
}
