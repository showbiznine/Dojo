using Windows.UI.Xaml;

namespace Dojo.Model
{
    public class DJMedia
    {
        public string media_type { get; set; }
        public string mime_type { get; set; }
        public string link { get; set; }
        public string base64 { get; set; }
        public float aspect_ratio { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int order { get; set; }
        public bool front_image { get; set; }
        public DJVersions versions { get; set; }
        public DJPreview preview { get; set; }

        public double CalculateHeight(float aspect_ratio)
        {
            var window_width = Window.Current.Bounds.Width;
            return window_width * 1 / aspect_ratio;
        }
    }
}
