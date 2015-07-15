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
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
            this.NavigationCacheMode = NavigationCacheMode.Required;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
         async void channel_PushNotificationReceived(Windows.Networking.PushNotifications.PushNotificationChannel sender, Windows.Networking.PushNotifications.PushNotificationReceivedEventArgs args)
        {
            if (args.ToastNotification.Content.InnerText.Contains("Event"))
            {
                //args.Cancel = true;

            }
            else
            {
                args.Cancel = true;
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    ChatPublic c = new ChatPublic();

                c.Message = args.ToastNotification.Content.InnerText;
                // c.Name = args.ToastNotification.Content.InnerText.Substring(index + 4, args.ToastNotification.Content.InnerText.Length - index + 5);
               test.Insert(0, c);
              

                });

                

            }
        }

         private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
         {
             Frame.GoBack();
             e.Handled = true;
         }
        void test_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lol.ItemsSource = test;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            PushNotificationChannel channel;
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
            channel.PushNotificationReceived+=channel_PushNotificationReceived;
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
            if (message.Text !="")
            {
                ChatPublic c = new ChatPublic();
                c.Name = "Test";
                c.Message = message.Text;
                message.Text = "";
                c.CreatedAt = DateTime.Today;
                await App.MobileService.GetTable<ChatPublic>().InsertAsync(c);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

       
            //BitmapImage bitmapImage = new BitmapImage();
            //Uri uri = new Uri(hi[14].ImageUri);
            //bitmapImage.UriSource = uri;
           
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        
    }
}
