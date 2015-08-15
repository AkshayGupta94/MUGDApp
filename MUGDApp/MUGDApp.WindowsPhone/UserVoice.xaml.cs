using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class UserVoice : Page
    {
        private List<string> ids;
        private IMobileServiceTable<idea> Table = App.MobileService.GetTable<idea>();
        private MobileServiceCollection<idea, idea> items;
        public UserVoice()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            int f = 0;
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile sampleFile =
                await folder.CreateFileAsync("Sample.txt", CreationCollisionOption.OpenIfExists);
            //await Windows.Storage.FileIO.WriteTextAsync(sampleFile, );
            try
            {
                string testlol = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                ids = JsonConvert.DeserializeObject<List<string>>(testlol);
            }
            catch (Exception ex)
            {

                f = 1;

                //List<idea> ai = new List<idea>();
                //idea i = new idea();
                //i.Title = "Test";
                //i.option1 = "Hello1";
                //i.option2 = "Hello2";
                //i.option3 = "Hello3";
                //ai.Add(i);

            }
            finally
            {
                if (f == 1)
                {
                    MessageDialog m = new MessageDialog("Oops... There was some Problem Handling your Request");
                    m.ShowAsync();

                }
                else
                {
                    items = await Table.ToCollectionAsync();
                    Voice.ItemsSource = items;
                }
            }
        }

        private async void Option1_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            idea i = temp.DataContext as idea;
            if (ids != null)
            {
                if (ids.Contains(i.Id))
                {
                    Windows.UI.Popups.MessageDialog mess = new Windows.UI.Popups.MessageDialog("You have already voted for this idea");
                    await mess.ShowAsync();
                }
                else
                {
                    ids.Add(i.Id);
                    string test = JsonConvert.SerializeObject(ids);
                    StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);

                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, test);
                    i.Countoption1++;
                    await Table.UpdateAsync(i);
                }
            }
            else
            {
                ids = new List<string>();
                ids.Add(i.Id);
                string test = JsonConvert.SerializeObject(ids);
                StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile sampleFile =
                    await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, test);
                i.Countoption1++;
                await Table.UpdateAsync(i);
            }
        }

        private async void Option2_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            idea i = temp.DataContext as idea;
            if (ids != null)
            {
                if (ids.Contains(i.Id))
                {
                    Windows.UI.Popups.MessageDialog mess = new Windows.UI.Popups.MessageDialog("You have already voted for this idea");
                    await mess.ShowAsync();
                }
                else
                {
                    ids.Add(i.Id);
                    string test = JsonConvert.SerializeObject(ids);
                    StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);

                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, test);
                    i.Countoption1++;
                    await Table.UpdateAsync(i);
                }
            }
            else
            {
                ids = new List<string>();
                ids.Add(i.Id);
                string test = JsonConvert.SerializeObject(ids);
                StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile sampleFile =
                    await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, test);
                i.Countoption2++;
                await Table.UpdateAsync(i);
            }
        }

        private async void Option3_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            idea i = temp.DataContext as idea;
            if (ids != null)
            {
                if (ids.Contains(i.Id))
                {
                    Windows.UI.Popups.MessageDialog mess = new Windows.UI.Popups.MessageDialog("You have already voted for this idea");
                    await mess.ShowAsync();
                }
                else
                {
                    ids.Add(i.Id);
                    string test = JsonConvert.SerializeObject(ids);
                    StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);

                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, test);
                    i.Countoption1++;
                    await Table.UpdateAsync(i);
                }
            }
            else
            {
                ids = new List<string>();
                ids.Add(i.Id);
                string test = JsonConvert.SerializeObject(ids);
                StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile sampleFile =
                    await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, test);
                i.Countoption3++;
                await Table.UpdateAsync(i);
            }
        }
    }
}
