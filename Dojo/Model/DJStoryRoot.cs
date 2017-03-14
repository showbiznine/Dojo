using System.Collections.ObjectModel;

namespace Dojo.Model
{
    public class DJStoryRoot
    {
        public ObservableCollection<DJContent> contents { get; set; }
        public DJStory story { get; set; }
    }
}
