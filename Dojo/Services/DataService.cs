using Dojo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        #endregion

        #region Methods

        #region User

        public static async Task<DJUser> LoginTemp()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(_host + "users/temporary");

            var res = await client.PostAsync(uri, new StringContent(string.Empty));
            var s = await res.Content.ReadAsStringAsync();

            var r = JsonConvert.DeserializeObject<DJUser>(s);
            return r;
        }
        #endregion


        #region Home
        
        #endregion

        #endregion
    }
}
