namespace Dojo.Model
{
    public class DJUserRoot
    {
        public DJUser user { get; set; }
    }

    public class DJUser
    {
        public string id { get; set; }
        public bool temporary { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public bool email_authorised { get; set; }
        public bool facebook_authorised { get; set; }
        public bool google_authorised { get; set; }
        public string api_key { get; set; }
    }
}
