using Dojo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Dojo.Controls
{
    public sealed partial class IdeaDetailsControl : UserControl
    {
        #region DependencyProperties


        public DJIdea Story
        {
            get { return (DJIdea)GetValue(StoryProperty); }
            set { SetValue(StoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Story.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StoryProperty =
            DependencyProperty.Register("Story", typeof(DJIdea), typeof(IdeaDetailsControl), new PropertyMetadata(0));

        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PhoneNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(IdeaDetailsControl), new PropertyMetadata(0));

        public string Website
        {
            get { return (string)GetValue(WebsiteProperty); }
            set { SetValue(WebsiteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Website.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WebsiteProperty =
            DependencyProperty.Register("Website", typeof(string), typeof(IdeaDetailsControl), new PropertyMetadata(0));

        public string TicketPrice
        {
            get { return (string)GetValue(TicketPriceProperty); }
            set { SetValue(TicketPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketPriceProperty =
            DependencyProperty.Register("TicketPrice", typeof(string), typeof(IdeaDetailsControl), new PropertyMetadata(0));

        //public Geopoint Location
        //{
        //    get { return (Geopoint)GetValue(LocationProperty); }
        //    set { SetValue(LocationProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Location.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty LocationProperty =
        //    DependencyProperty.Register("Location", typeof(Geopoint), typeof(StoryDetailsControl), new PropertyMetadata(new Geopoint());

        #endregion



        public IdeaDetailsControl()
        {
            this.InitializeComponent();
        }
    }
}
