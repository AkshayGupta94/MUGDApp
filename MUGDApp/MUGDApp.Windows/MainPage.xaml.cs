using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WinRTXamlToolkit;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MUGDApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static ObservableCollection<ChatPubList> test;
        private IMobileServiceTable<ChatPublic> Table = App.MobileService.GetTable<ChatPublic>();
        private MobileServiceCollection<ChatPublic, ChatPublic> items;

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
           


        }

        

        void test_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lol.ItemsSource = test;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            //PushNotificationChannel channel;
            //channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            //try
            //{
            //    await App.Mugd_appClient.GetPush().RegisterNativeAsync(channel.Uri);
            //    //await App.Mugd_appClient.InvokeApiAsync("notifyAllUsers",
            //    //    new JObject(new JProperty("toast", "Sample Toast")));
            //}
            //catch (Exception exception)
            //{
            //    HandleRegisterException(exception);
            //}
            Start.channel.PushNotificationReceived += channel_PushNotificationReceived;
            test = new ObservableCollection<ChatPubList>();

            items = await Table.OrderByDescending(ChatPublic => ChatPublic.CreatedAt).ToCollectionAsync();
            var networkProfiles = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles();
            var adapter = networkProfiles.First<Windows.Networking.Connectivity.ConnectionProfile>().NetworkAdapter;//takes the first network adapter
            string networkAdapterId = adapter.NetworkAdapterId.ToString();

            foreach (ChatPublic k in items)
            {
                ChatPubList a = new ChatPubList();
                a.Name = k.Name;
                a.Message = k.Message;
                if (a.Name == networkAdapterId)
                {
                    a.col = "White";
                }
                else
                {
                    a.col = "#FFFF003A";
                }
                test.Add(a);
            }
            lol.ItemsSource = test;
            test.CollectionChanged += test_CollectionChanged;
            

        }
        async void channel_PushNotificationReceived(Windows.Networking.PushNotifications.PushNotificationChannel sender, Windows.Networking.PushNotifications.PushNotificationReceivedEventArgs args)
        {
            if (args.ToastNotification.Content.InnerText.Contains("Event"))
            {
               

            }
            else
            {
                args.Cancel = true;
                items = await Table.OrderByDescending(ChatPublic => ChatPublic.CreatedAt).Take(1).ToCollectionAsync();
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {

                    ChatPubList a = new ChatPubList();

                    a.Message = items[0].Message;
                    a.Name = items[0].Name;
                    var networkProfiles = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles();
                    var adapter = networkProfiles.First<Windows.Networking.Connectivity.ConnectionProfile>().NetworkAdapter;//takes the first network adapter
                    string networkAdapterId = adapter.NetworkAdapterId.ToString();
                    if (a.Name == networkAdapterId)
                    {
                        a.col = "White";
                    }
                    else
                    {
                        a.col = "#FFFF003A";
                    }
                    MainPage.test.Insert(0, a);


                });




            }
        }
        private static void HandleRegisterException(Exception exception)
        {

        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            if (message.Text != "")
            {
                ChatPublic c = new ChatPublic();
                var networkProfiles = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles();
                var adapter = networkProfiles.First<Windows.Networking.Connectivity.ConnectionProfile>().NetworkAdapter;//takes the first network adapter
                string networkAdapterId = adapter.NetworkAdapterId.ToString();


                c.Name = networkAdapterId;
                c.Message = message.Text;
                message.Text = "";
                c.CreatedAt = DateTime.Now;
                await App.MobileService.GetTable<ChatPublic>().InsertAsync(c);
            }
        }
    }
}
