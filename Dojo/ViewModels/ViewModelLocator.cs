using Dojo.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {
                var navigationService = InitNavigationService();
                // Create run time view services and models
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ListingViewModel>();
            SimpleIoc.Default.Register<StoryViewModel>();
        }

        private INavigationService InitNavigationService()
        {
            var service = new NavigationService();

            service.Configure(typeof(MainViewModel).FullName, typeof(MainPage));
            //service.Configure(typeof(SettingsViewModel).FullName, typeof(SettingsPage));
            service.Configure(typeof(StoryViewModel).FullName, typeof(StoryPage));
            service.Configure(typeof(ListingViewModel).FullName, typeof(ListingPage));

            return service;
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }

        public ListingViewModel Listing
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListingViewModel>();
            }
        }

        public StoryViewModel Story
        {
            get { return ServiceLocator.Current.GetInstance<StoryViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
