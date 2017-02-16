using Dojo.Model;
using Microsoft.QueryStringDotNET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Dojo.Model.Base;

namespace Dojo.Services
{
    public class DataService
    {
        #region Fields
        public static string _host = "https://apiv3.dojoapp.co/mobile/v3-1/";
        public static string _apiKey;
        #endregion

        #region Methods

        #region User

        public static async Task<DJUserRoot> LoginTemp()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(_host + "users/temporary");

            var res = await client.PostAsync(uri, new StringContent(string.Empty));
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJUserRoot>(s);

            _apiKey = r.user.api_key;
            return r;
        }

        #endregion


        #region Home

        public static async Task<DJIdeasRoot> GetIdeas()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", _apiKey);
            var uri = new Uri(_host + "LON/home/ideas");

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJIdeasRoot>(s);
            return r;
        }

        public static async Task<DJCategoriesRoot> GetCategories()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", _apiKey);
            var uri = new Uri(_host + "LON/home/categories");

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJCategoriesRoot>(s);
            return r;
        }

        public static async Task<DJCollectionsRoot> GetCollections()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", _apiKey);
            var uri = new Uri(_host + "LON/home/collections");

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJCollectionsRoot>(s);
            return r;
        }

        #endregion

        #region Location

        public static async Task<DJLocationSuccess> SetLocation(double lat, double lon)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", _apiKey);
            var q = new QueryString
            {
                {"lat", lat.ToString() },
                {"long", lon.ToString() }
            };
            var uri = new Uri(_host + "locations?" + q);

            var res = await client.GetAsync(uri);
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJLocationSuccess>(s);
            return r;
        }
        #endregion

        #endregion
    }
}
