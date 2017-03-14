using Dojo.Constants;
using Dojo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Dojo.Services
{
    public class AppDataService
    {
        private const string _remoteJson = "https://api.myjson.com/bins/14gsdt";

        #region Settings
        public static object LoadLocalSetting(string key)
        {
            return ApplicationData.Current.LocalSettings.Values[key];
        }

        public static object LoadRoamingSetting(string key)
        {
            return ApplicationData.Current.RoamingSettings.Values[key];
        }

        public static void SaveLocalSetting(string key, object value)
        {
            if (ApplicationData.Current.LocalSettings.Values[key] != null)
                ApplicationData.Current.LocalSettings.Values[key] = value;
            else
                ApplicationData.Current.LocalSettings.Values.Add(key, value);
        }

        public static void SaveRoamingSetting(string key, object value)
        {
            if (ApplicationData.Current.RoamingSettings.Values[key] != null)
                ApplicationData.Current.RoamingSettings.Values[key] = value;
            else
                ApplicationData.Current.RoamingSettings.Values.Add(key, value);
        }
        #endregion

        #region Files
        public static async Task<StorageFile> LoadLocalFileAsync(string fileName)
        {
            try
            {
                return await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public static async Task<StorageFile> LoadRoamingFileAsync(string fileName)
        {
            try
            {
                return await ApplicationData.Current.RoamingFolder.GetFileAsync(fileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public static async Task<StorageFile> SaveLocalFileAsync(string fileName, CreationCollisionOption collisionOptions)
        {
            return await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, collisionOptions);
        }

        public static async Task<StorageFile> SaveRoamingFile(string fileName, CreationCollisionOption collisionOptions)
        {
            return await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, collisionOptions);
        }
        #endregion

        #region RemoteSettings

        public static async Task<RemoteSettings> LoadRemoteSettings()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(_remoteJson);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<RemoteSettings>(s);

            return r;
        }

        public static async Task<bool> SaveRemoteSettings()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(_remoteJson);

            var content = new Random().Next(1000, 2000).ToString();
            var json = JsonConvert.SerializeObject(new RemoteSettings
            {
                test_value = content
            });

            var res = await client.PutAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            var s = await res.Content.ReadAsStringAsync();

            return res.IsSuccessStatusCode;

        }
        #endregion

        #region Milestones
        public static void SaveFirstRun()
        {
            SaveLocalSetting(Settings.firstRun, DateTime.Now);
        }

        public static DateTime LoadFirstRun()
        {
            var fr = LoadLocalSetting(Settings.firstRun);
            if (fr == null)
            {
                var now = DateTime.Now;
                SaveLocalSetting(Settings.firstRun, now);
                return now;
            }
            else
                return (DateTime)fr;

        }
        #endregion
    }
}
