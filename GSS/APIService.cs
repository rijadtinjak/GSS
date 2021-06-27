using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSS.Model;
using System.IO;

namespace GSS
{
    public class APIService
    {
        public static string Email { get; set; }
        public static string Password { get; set; }
        private readonly string _route = null;
        public static Model.User LoggedInUser { get; set; }
        public static bool OfflineMode { get; set; }
        public static int OfflineModeUserId { get; set; }

        public static List<Manager> Managers { get; set; }

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search, string actionName = null)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                if (actionName != null)
                    url += "/" + actionName;
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Email, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Unauthorized access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            try
            {
                return await url.WithBasicAuth(Email, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Unauthorized access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Email, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Unauthorized access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                    if (errors != null)
                    {

                        var stringBuilder = new StringBuilder();
                        foreach (var error in errors)
                        {
                            stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                        }

                        MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                return default(T);
            }

        }
        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Email, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Unauthorized access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                    if (errors != null)
                    {

                        var stringBuilder = new StringBuilder();
                        foreach (var error in errors)
                        {
                            stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                        }

                        MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                return default(T);
            }
        }

        public async Task<bool> Delete(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Email, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Unauthorized access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                    if (errors != null)
                    {

                        var stringBuilder = new StringBuilder();
                        foreach (var error in errors)
                        {
                            stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                        }

                        MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                return false;
            }
        }


        public async Task<bool> UploadSearchBackup(string SearchName, string filePath)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/Backup/{SearchName}";

            try
            {
                return await url.WithBasicAuth(Email, Password).PostMultipartAsync(
                        mp => mp.AddFile("Backup", filePath)
                       .AddStringParts(new { LastModified = File.GetLastWriteTime(filePath) })
                    ).ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Unauthorized access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                    if (errors != null)
                    {

                        var stringBuilder = new StringBuilder();
                        foreach (var error in errors)
                        {
                            stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                        }

                        MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                return false;
            }

        }
    }
}
