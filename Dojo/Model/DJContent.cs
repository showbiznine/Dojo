namespace Dojo.Model
{
    public class DJContent
    {
        public int content_type { get; set; }
        public int padding { get; set; }
        public int order { get; set; }
        public DJMedia[] medias { get; set; }
        public DJText text { get; set; }
        public bool follow_button { get; set; }
        public DJListing listing { get; set; }
    }
}
