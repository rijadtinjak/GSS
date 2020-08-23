using GSS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS.Helper
{
    public static class ManagerHelper
    {
        public async static Task<List<Manager>> LoadFromAPI()
        {
            var service = new APIService("Manager");
            return await service.Get<List<Manager>>(null);
        }

        public static void SaveToFile(int UserId, List<Manager> managers)
        {
            string appDir = FileHelper.GetAppDir();

            var managersDir = Path.Combine(appDir, "managers");
            if(!Directory.Exists(managersDir))
            {
                try
                {
                    Directory.CreateDirectory(managersDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not create managers directory at" + managersDir + ".\nError: " + ex.Message, "Error creating directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string fileName = UserId + ".bin";
            string filePath = Path.Combine(managersDir, fileName);

            using (FileStream stream = File.Open(filePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, managers);
            }

        }

        public static List<Manager> LoadFromFile(int UserId)
        {
            List<Manager> managers = null;
            string appDir = FileHelper.GetAppDir();
            var filePath = Path.Combine(appDir, "managers", UserId + ".bin");

            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    if (stream.Length == 0)
                        return null;

                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    try
                    {
                        managers = (List<Manager>)bformatter.Deserialize(stream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could deserialize load managers from file " + filePath + ".\nError: " + ex.Message, "Error loading managers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load managers from file " + filePath + ".\nError: " + ex.Message, "Error loading managers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            return managers;
        }

    }
}
