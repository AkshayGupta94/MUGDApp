using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Phone.UI.Input;
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
    /// 

 



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
            List<EventList> item = new List<EventList>();
            int f = 0;
            try
            {
                items = await Table.Where(Events
                    => Events.imageUri != null).ToCollectionAsync();

                foreach (Events eve in items)
                {
                    EventList temp = new EventList();
                    temp.Id = eve.Id;
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
                    //temp.date = eve.date;
                    temp.Title = eve.Title;
                    temp.bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(eve.imageUri));
                    var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;

                    temp.width = Window.Current.Bounds.Width * scaleFactor * 0.72;
                    temp.height = Window.Current.Bounds.Height * scaleFactor * 0.3125;

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

            }
            catch (Exception e1)
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
       
       

        private void Menu_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            EventList a = e.ClickedItem as EventList;
            Events lol = new Events();
            foreach (Events eve in items)
            {
                if (a.Id == eve.Id)
                {
                    lol = eve;
                }
            }

            Frame.Navigate(typeof(eventDetailxaml), lol);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Start));
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {

            Frame.Navigate(typeof(Start));
            e.Handled = true;
        }
    }
}
