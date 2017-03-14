using Dojo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Dojo.Converters
{
    public class ContentTypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderImageTemplate { get; set; }
        public DataTemplate HeaderTextTemplate { get; set; }
        public DataTemplate UnknownContentTypeTemplate { get; set; }
        public DataTemplate SeperatorTextTemplate { get; set; }
        public DataTemplate IdeaImageTemplate { get; set; }
        public DataTemplate SpotifyPreviewTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var content = item as DJContent;
            switch (content.content_type)
            {
                case DJContentType.HeaderImage:
                    return HeaderImageTemplate;
                case DJContentType.IdeaImage:
                    return IdeaImageTemplate;
                case DJContentType.Seperator:
                    return SeperatorTextTemplate;
                case DJContentType.SpotifyPreview:
                    return SpotifyPreviewTemplate;
                case DJContentType.Text:
                    return HeaderTextTemplate;
                default:
                    return UnknownContentTypeTemplate;
            }
        }
    }
}
