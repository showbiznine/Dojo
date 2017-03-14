using Dojo.Constants;
using Dojo.Dialogs;
using Dojo.Model;
using Dojo.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Dojo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        public DJUser CurrentUser { get; set; }
        public ObservableCollection<DJIdea> Ideas { get; set; }
        public ObservableCollection<DJCategory> Categories { get; set; }
        public ObservableCollection<DJCollection> Collections { get; set; }
        public string TestValue { get; set; }
        #endregion

        #region Fields
        protected INavigationService NavigationService { get { return ServiceLocator.Current.GetInstance<INavigationService>(); } }
        #endregion

        #region Commands
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand LoginTempCommand { get; set; }
        public RelayCommand GetIdeasCommand { get; set; }
        public RelayCommand HamburgerClickCommand { get; set; }
        public RelayCommand<ItemClickEventArgs> IdeaTapCommand { get; set; }
        public RelayCommand<DJListing> ListingTapCommand { get; set; }
        #endregion

        #region Methods

        public MainViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                Ideas = new ObservableCollection<DJIdea>();
                Categories = new ObservableCollection<DJCategory>();
                Collections = new ObservableCollection<DJCollection>();

                InitializeCommands();

                SetupHome();
            }
        }

        private async void SetupHome()
        {
            var tok = AppDataService.LoadLocalSetting(Settings.apiKey);
            if (tok is null)
                await DataService.LoginTemp();
            await LoadIdeas();
            await LoadCategoriesAsync();
            await LoadCollections();
        }

        private void InitializeCommands()
        {
            LoginTempCommand = new RelayCommand(async () =>
            {
                var u = await DataService.LoginTemp();
                CurrentUser = u.user;
            });
            GetIdeasCommand = new RelayCommand(async () => await LoadIdeas());
            IdeaTapCommand = new RelayCommand<ItemClickEventArgs>(async args =>
            {
                var clickedItem = args.ClickedItem as DJIdea;
                try
                {
                    if (clickedItem.type == "listing")
                    {
                        App.ViewModelLocator.Listing.CurrentListing = clickedItem.listing;
                        NavigationService.NavigateTo(typeof(ListingViewModel).FullName);
                    }
                    else if (clickedItem.type == "story")
                    {
                        App.ViewModelLocator.Story.CurrentStory = await DataService.LoadStory(clickedItem.story.id);
                        NavigationService.NavigateTo(typeof(StoryViewModel).FullName);
                    }

                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            });
            HamburgerClickCommand = new RelayCommand(async () =>
            {
                await AppDataService.SaveRemoteSettings();
                if (true)
                {
                    var test = await AppDataService.LoadRemoteSettings();
                    TestValue = test.test_value;
                }
            });
        }

        private async Task LoadIdeas()
        {
            var r = await DataService.GetIdeas();
            foreach (var idea in r.ideas)
            {
                Ideas.Add(idea);
            }
        }

        private async Task LoadCategoriesAsync()
        {
            var r = await DataService.GetCategories();
            foreach (var cat in r.categories)
            {
                Categories.Add(cat);
            }
        }

        private async Task LoadCollections()
        {
            var r = await DataService.GetCollections();
            foreach (var col in r.collections)
            {
                Collections.Add(col);
            }
        }

        private async void SetLocation()
        {
            var loc = new Geolocator();
            var c = await loc.GetGeopositionAsync();
            var r = await DataService.SetLocation(c.Coordinate.Point.Position.Latitude, c.Coordinate.Point.Position.Longitude);
        }
        #endregion
    }
}
