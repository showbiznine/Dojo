namespace Dojo.Model
{
    public class DJIdea
    {
        public string name { get; set; }
        public object order { get; set; }
        public string type { get; set; }
        public int relation_id { get; set; }
        public bool is_big { get; set; }
        //public DJTime time { get; set; }
        public DJListing listing { get; set; }
        //public Media1 media { get; set; }
        public DJStory story { get; set; }
    }
}
