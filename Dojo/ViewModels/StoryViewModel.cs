using Dojo.Model;
using Dojo.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.ViewModels
{
    public class StoryViewModel : ViewModelBase
    {
        public DJStoryRoot CurrentStory { get; set; }

        public StoryViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                InitializeCommands();
            }
        }

        private void InitializeCommands()
        {

        }
    }
}
