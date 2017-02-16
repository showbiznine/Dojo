namespace Dojo.Model
{
    public class DJCollection
    {
        public string id { get; set; }
        public string name { get; set; }
        public string created_by { get; set; }
        public DJMedia media { get; set; }
        public int contents_length { get; set; }
        public bool followed { get; set; }
    }
}
