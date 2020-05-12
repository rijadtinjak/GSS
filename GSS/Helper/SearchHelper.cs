using GSS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GSS.Helper
{
    public static class SearchHelper
    {
        public static void SetUpSearch(this Search search, /*int numOfZones, */List<Manager> managers, List<Person> missingPeople, decimal lat, decimal lng, DateTime dateReportedMissing)
        {
            search.Zones = new List<Zone>();
            search.Managers = managers;
            search.MissingPeople = missingPeople;
            search.Lat = lat;
            search.Lng = lng;
            search.DateReportedMissing = dateReportedMissing;
            //for (int i = 0; i < numOfZones; i++)
            //{
            //    search.Zones.Add(new Zone
            //    {
            //        Name = "Zone " + Convert.ToChar(65 + i)
            //    });

            //    Zone zone = search.Zones.Last();
            //    foreach (var manager in search.Managers)
            //    {
            //        zone.Consensus.Add(new Consensus { Zone = zone, Manager = manager, Value = 0 });
            //    }

            //}
        }

        public async static void SaveToFile(this Search search)
        {
            string appDir = FileHelper.GetAppDir();

            string fileName = search.Name + ".bin";
            string filePath = Path.Combine(appDir, fileName);

            if (APIService.LoggedInUser != null && search.UserId == 0)
            {
                search.UserId = APIService.LoggedInUser.Id;
                search.User = APIService.LoggedInUser;
            }

            using (FileStream stream = File.Open(filePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, search);
            }

            if (NetworkHelper.IsUp() && APIService.LoggedInUser != null)
            {
                APIService _searchService = new APIService("Search");
                await _searchService.Insert<Search>(search).ConfigureAwait(false);
                await _searchService.UploadSearchBackup(search.Name, filePath);
            }

        }

        public static Search LoadFromFile(string filePath)
        {
            Search search;

            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                if (stream.Length == 0)
                    return null;

                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                search = (Search)bformatter.Deserialize(stream);
            }

            return search;
        }

    }
}
