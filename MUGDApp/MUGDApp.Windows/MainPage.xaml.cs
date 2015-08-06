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
        public static ObservableCollection<ChatPublic> test;
        private IMobileServiceTable<ChatPublic> Table = App.MobileService.GetTable<ChatPublic>();
        private MobileServiceCollection<ChatPublic, ChatPublic> items;

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
            
            //Mugd_appPush.channel.PushNotificationReceived += channel_PushNotificationReceived;

          

            //k = new Events();
            //k.college = "Bvcoe";
            //k.Desc = "lol";
            //k.Title = "test";
            //test.Insert(0, k);
            //lol.ItemsSource = test;
            //for(int i=0;i<10;i++)
            //{

            //    k = new Events();
            //    k.college = "Bvcoe";
            //    k.Desc = "lol";
            //    k.Title = "test" + i.ToString();
            //    test.Insert(0, k);
            //}
           

        }

        

        void test_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lol.ItemsSource = test;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
           
            test = new ObservableCollection<ChatPublic>();
            
            items = await Table.ToCollectionAsync();
            foreach(ChatPublic k in items)
            {
               test.Insert(0,k);
            }
            lol.ItemsSource = test;
            test.CollectionChanged += test_CollectionChanged;
        }
        private static void HandleRegisterException(Exception exception)
        {

        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            ChatPublic c = new ChatPublic();
            c.Name = "Test";
            c.Message = message.Text;
            c.CreatedAt = DateTime.Today;
            await App.MobileService.GetTable<ChatPublic>().InsertAsync(c);
        }
    }
}
