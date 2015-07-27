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
            temp.back = "#FFD71A20";
            temp.name = "Chats";
            temp.src = "Pics/chat.png";
            temp.title = "Chats";
            temp.desc = "Use this option to add new members to the group, This is similar to registeration and will not generate any user id and passwords";
            myList.Add(temp);
            temp = new datamodel();

            temp.name = "Events";
            temp.back = "#FF00BFF3";
            temp.src = "Pics/Event.png";
            temp.title = "Events";
            temp.desc = "Use this option to mark attendance of the members present at the event";
            myList.Add(temp);
            temp = new datamodel();

            temp.name = "User Voice";
            temp.back = "#FFFF8E01";
            temp.src = "Pics/idea.png";
            temp.title = "User Voice";
            temp.desc = "Use this option to find members and see their details";
            myList.Add(temp);
            temp = new datamodel();

            temp.name = "Member Login";
            temp.back = "#FF7CC576";
            temp.src = "Pics/login.png";
            temp.title = "Member Login";
            temp.desc = "Use this option to update members database";
            myList.Add(temp);
            
            Menu.DataContext = myList;
        }
      
        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            datamodel lolol = e.ClickedItem as datamodel;
            if (lolol.name == "Events")
            {
                Frame.Navigate(typeof(Eventspage));
            }
            else if (lolol.title == "Chats")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else if (lolol.title == "Idea's")
            {
                Frame.Navigate(typeof(Eventspage));
            }
            else if (lolol.title == "Member Login")
            {
                Frame.Navigate(typeof(loginMember));
            }

        }
           
     
    }
}
