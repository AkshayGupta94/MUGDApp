using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using Windows.Networking.PushNotifications;
using System.Threading;

// http://go.microsoft.com/fwlink/?LinkId=290986&clcid=0x409

namespace MUGDApp
{
    internal class Mugd_appPush
    {
        //public static PushNotificationChannel channel = null;
        public static string a = "hi";

       

        public static void UploadChannel()
        {
            //channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            a = "bye";
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
            
           
            
           
        }

        static void channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {

            

        }

        private static void HandleRegisterException(Exception exception)
        {

        }
    }
}
