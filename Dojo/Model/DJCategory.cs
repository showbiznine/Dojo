namespace Dojo.Model
{
    public class DJCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public bool calendar_view { get; set; }
        public DJMedia media { get; set; }
        public bool hero { get; set; }
        public string mongo_id { get; set; }
    }
}
