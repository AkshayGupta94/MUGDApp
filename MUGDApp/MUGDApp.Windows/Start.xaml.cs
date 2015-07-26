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
    public sealed partial class Start : Page
    {
        public Start()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<datamodel> myList = new List<datamodel>();
            datamodel temp = new datamodel();
            temp.back = "Red";
            temp.name = "Register";
            temp.src = "/Assets/Plus.png";
            temp.title = "Add new member";
            temp.desc = "Use this option to add new members to the group, This is similar to registeration and will not generate any user id and passwords";
            myList.Add(temp);
            temp = new datamodel();

            temp.name = "Attendance";
            temp.back = "Red";
            temp.src = "/Assets/register.png";
            temp.title = "Mark Attendance";
            temp.desc = "Use this option to mark attendance of the members present at the event";
            myList.Add(temp);
            temp = new datamodel();

            temp.name = "Search";
            temp.back = "Red";
            temp.src = "/Assets/search.png";
            temp.title = "Search For members";
            temp.desc = "Use this option to find members and see their details";
            myList.Add(temp);
            temp = new datamodel();

            temp.name = "Update";
            temp.back = "Red";
            temp.src = "/Assets/update.png";
            temp.title = "Update the database";
            temp.desc = "Use this option to update members database";
            myList.Add(temp);

            Menu.DataContext = myList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Events));
        }

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            datamodel lolol = e.ClickedItem as datamodel;
            if (lolol.title == "Register")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else if (lolol.title == "Delete user")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else if (lolol.title == "Search For users")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else if (lolol.title == "Add College")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else if (lolol.title == "Remove College")
            {
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
