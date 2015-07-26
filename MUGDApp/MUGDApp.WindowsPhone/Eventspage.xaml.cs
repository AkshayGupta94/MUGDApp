using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MUGDApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Eventspage : Page
    {
        private IMobileServiceTable<Events> Table = App.MobileService.GetTable<Events>();
        private MobileServiceCollection<Events, Events> items;

        public Eventspage()
        {
            this.InitializeComponent();
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Events> ob = new List<Events>();
            items = await Table.ToCollectionAsync();
            foreach (Events erg in items)
            {
                Events f = new Events();
                f.Desc = erg.Desc;
                ob.Add(f);
            }
            listEvent.ItemsSource = ob;    //list view data
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
            else
            {
                Frame.Navigate(typeof(Start));
            }
                e.Handled = true;
        }

        private void eventGrid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
           
        }

        private void eventGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void listEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Events a = listEvent.SelectedItem as Events;
            Frame.Navigate(typeof(eventDetailxaml), a);
        }
        
    }
}
