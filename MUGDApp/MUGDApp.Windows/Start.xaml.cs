using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.PushNotifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MUGDApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Start : Page
    {
        public static PushNotificationChannel channel;
        private IMobileServiceTable<ChatPublic> Table = App.MobileService.GetTable<ChatPublic>();
        private MobileServiceCollection<ChatPublic, ChatPublic> items;
        public Start()
        {
            this.InitializeComponent();
            Loaded += Start_Loaded;
        }
        private async void Start_Loaded(object sender, RoutedEventArgs e)
        {
            
            channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            try
            {
                await App.Mugd_appClient.GetPush().RegisterNativeAsync(channel.Uri);
                //await App.Mugd_appClient.InvokeApiAsync("notifyAllUsers",
                //    new JObject(new JProperty("toast", "Sample Toast")));
            }
            catch (Exception exception)
            {
                HandleRegisterException(exception);
            }
            channel.PushNotificationReceived += channel_PushNotificationReceived;
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
            else if (lolol.title == "User Voice")
            {
                Frame.Navigate(typeof(UserVoice));
            }
            else if (lolol.title == "Member Login")
            {
                Frame.Navigate(typeof(loginMember));
            }

        }

      void channel_PushNotificationReceived(Windows.Networking.PushNotifications.PushNotificationChannel sender, Windows.Networking.PushNotifications.PushNotificationReceivedEventArgs args)
        {
            if (args.ToastNotification.Content.InnerText.Contains("Event"))
            {
                //args.Cancel = true;

            }
            else
            {
                args.Cancel = true;
                //items = await Table.OrderByDescending(ChatPublic => ChatPublic.CreatedAt).Take(1).ToCollectionAsync();

                //await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                //{

                //    ChatPubList a = new ChatPubList();

                //    a.Message = items[0].Message;
                //    a.Name = items[0].Name;
                //    MainPage.test.Insert(0, a);

                //});



            }
        }
        private static void HandleRegisterException(Exception exception)
        {

        }

    }
}
