using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
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
            int f = 0;
            List<EventList> item = new List<EventList>();
            EventList temp = new EventList();
            try
            {
                items = await Table.Where(Events
                    => Events.imageUri != null).ToCollectionAsync();
                foreach (Events eve in items)
                {
                    temp = new EventList();
                    if (eve.college.Length <= 14)
                    {
                        temp.college = eve.college;
                    }
                    else
                    { temp.college = eve.college.Substring(0, 14); }

                    if (eve.Desc.Length <= 140)
                    {
                        temp.Desc = eve.Desc;
                    }
                    else
                    { temp.Desc = eve.Desc.Substring(0, 140); }
                    temp.date = eve.Date.Date.ToString("dd/MM/yyyy");
                    temp.type = eve.type;
                    if (temp.type == "MUGD")
                    {
                        temp.back = "#FF00BFF3";
                    }
                    else
                    {
                        temp.back = "#FFFFD700";
                    }
                    temp.issuedBy = eve.issuedBy;
                    temp.Id = eve.Id;
                    temp.Title = eve.Title;
                    temp.bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(eve.imageUri));
                    item.Add(temp);




                }
                
            }
            catch (Exception)
            {
                f = 1;
            }
            finally
            {
                if (f == 1)
                {
                    MessageDialog m = new MessageDialog("Oops... There was some Problem Handling your Request");
                    await m.ShowAsync();

                }
                else
                {
                    event1.DataContext = item;
                    
                }
            }
        }
        

              private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Start));
        }
   
      

        private void Menu_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Events ev = new Events();
            EventList a = e.ClickedItem as EventList;
            foreach(Events eve in items)
            {
                if(a.Id==eve.Id)
                {
                    ev = eve;
                    break;
                }

            }
            Frame.Navigate(typeof(eventDetail), ev);

        }
        
    }
}
