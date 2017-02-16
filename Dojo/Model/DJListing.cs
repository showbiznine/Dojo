namespace Dojo.Model
{
    public class DJListing
    {
        public string id { get; set; }
        public string type { get; set; }
        public int? author { get; set; }
        public string name { get; set; }
        public string subtitle { get; set; }
        public DJCoordinates coordinates { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string station { get; set; }
        public int? rating { get; set; }
        public DJAddress address { get; set; }
        public string pretty_url { get; set; }
        public string ticket_price { get; set; }
        public string ticket_url { get; set; }
        public string venue_name { get; set; }
        //public DJTimes times { get; set; }
        public object[] collection_ids { get; set; }
        public string listingContext_id { get; set; }
        public string slug { get; set; }
        public DJMedia[] medias { get; set; }
        public DJTip tip { get; set; }
        public string language_id { get; set; }
        public object review { get; set; }
        public bool recently_added { get; set; }
        public string context_id { get; set; }
        public string mongo_id { get; set; }
        public int price_rating { get; set; }
        public DJStamp stamp { get; set; }
    }


}
