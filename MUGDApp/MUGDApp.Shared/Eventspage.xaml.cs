using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            items = await Table.Where(Events
                => Events.ImageUri!= null).ToCollectionAsync();
            List<EventList> item = new List<EventList>();
            foreach (Events eve in items)
            {
                EventList temp = new EventList();
                temp.college = eve.college;
                temp.Desc = eve.Desc;
                temp.Date = eve.Date;
                temp.type = eve.type;
                temp.issuedBy = eve.issuedBy;
                temp.date = eve.date;
                temp.Title = eve.Title;
                temp.bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(eve.ImageUri));
                item.Add(temp);
            }
            //List<Events> myList1 = new List<Events>();
            //Events temp1 = new Events();
            //temp1.college = "college";
            //temp1.date = DateTime.Now.ToString("dd/MM/yyyy");
            //temp1.Desc = "this is the about page hellooooo hkbdssasdnathis is the about page hellooooo hkbdssasdnathis is the about page hellooooo hkbdssasdna";
            //temp1.Title = "this is title";
            //temp1.ImageUri = "/Pics/area51.jpg";
            //myList1.Add(temp1);
            event1.DataContext = item;
           
        }
       

        private void eventGrid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
           
        }

        private void eventGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void listEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // Events a = listEvent.SelectedItem as Events;
            //Frame.Navigate(typeof(eventDetailxaml), a);
        }

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Menu_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }
        
    }
}
