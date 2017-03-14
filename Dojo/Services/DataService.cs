using Dojo.Constants;
using Dojo.Model;
using Microsoft.QueryStringDotNET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Dojo.Model.Base;

namespace Dojo.Services
{
    public class DataService
    {

        #region Methods

        #region User

        public static async Task<DJUserRoot> LoginTemp()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(API.Host + API.Users +  "/temporary");

            var res = await client.PostAsync(uri, new StringContent(string.Empty));
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJUserRoot>(s);

            AppDataService.SaveLocalSetting(Settings.apiKey, r.user.api_key);
            Debug.WriteLine("Logged in as temporary user - API key = " + r.user.api_key);

            return r;
        }

        #endregion

        #region Home

        public static async Task<DJIdeasRoot> GetIdeas()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", (string)AppDataService.LoadLocalSetting(Settings.apiKey));
            var uri = new Uri(Constants.API.Host + API.London + API.Home + API.Ideas);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJIdeasRoot>(s);
            return r;
        }

        public static async Task<DJCategoriesRoot> GetCategories()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", (string)AppDataService.LoadLocalSetting(Settings.apiKey));
            var uri = new Uri(Constants.API.Host + API.London + API.Home + API.Categories);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJCategoriesRoot>(s);
            return r;
        }

        public static async Task<DJCollectionsRoot> GetCollections()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", (string)AppDataService.LoadLocalSetting(Settings.apiKey));
            var uri = new Uri(API.Host + API.London + API.Home + API.Collections);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJCollectionsRoot>(s);
            return r;
        }

        #endregion

        #region Stories

        public static async Task<DJStoryRoot> LoadStory(string StoryID)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", (string)AppDataService.LoadLocalSetting(Settings.apiKey));
            var uri = new Uri(API.Host + API.London + API.Stories +  "/" + StoryID);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJStoryRoot>(s);
            Debug.WriteLine("Loaded Story " + r.story.name + "ID: " + r.story.id);
            return r;
        }
        #endregion

        #region Location

        public static async Task<DJLocationSuccess> SetLocation(double lat, double lon)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", (string)AppDataService.LoadLocalSetting(Settings.apiKey));
            var q = new QueryString
            {
                {"lat", lat.ToString() },
                {"long", lon.ToString() }
            };
            var uri = new Uri(API.Host + API.Locations + q);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJLocationSuccess>(s);
            return r;
        }
        #endregion

        #endregion
    }
}
