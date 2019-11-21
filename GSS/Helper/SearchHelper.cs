using GSS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GSS.Helper
{
    public static class SearchHelper
    {
        public static void SetUpSearch(this Search search, int numOfZones, List<Manager> managers)
        {
            search.Zones = new List<Zone>();
            search.Managers = managers;
            for (int i = 0; i < numOfZones; i++)
            {
                search.Zones.Add(new Zone
                {
                    Name = "Zone " + Convert.ToChar(65 + i)
                });

                Zone zone = search.Zones.Last();
                foreach (var manager in search.Managers)
                {
                    zone.Consensus.Add(new Consensus { Zone = zone, Manager = manager, Value = 0 });
                }

            }
        }

        public async static void SaveToFile(this Search search)
        {
            if (NetworkHelper.IsUp())
            {
                APIService _searchService = new APIService("Search");
                _searchService.Insert<Model.Search>(search);
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
