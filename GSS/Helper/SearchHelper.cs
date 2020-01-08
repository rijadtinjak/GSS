using GSS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GSS.Helper
{
    public static class SearchHelper
    {
        public static void SetUpSearch(this Search search, /*int numOfZones, */List<Manager> managers, decimal lat, decimal lng)
        {
            search.Zones = new List<Zone>();
            search.Managers = managers;
            search.Lat = lat;
            search.Lng = lng;
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
            if (NetworkHelper.IsUp() && APIService.LoggedInUser != null)
            {
                APIService _searchService = new APIService("Search");
                await _searchService.Insert<Search>(search).ConfigureAwait(false);
            }

            string appDir = FileHelper.GetAppDir();

            string fileName = search.Name + ".bin";
            string filePath = Path.Combine(appDir, fileName);


            using (FileStream stream = File.Open(filePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, search);
            }

        }

        public static Search LoadFromFile(string filePath)
        {
            Search search;

            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                search = (Search)bformatter.Deserialize(stream);
            }

            return search;
        }

    }
}
