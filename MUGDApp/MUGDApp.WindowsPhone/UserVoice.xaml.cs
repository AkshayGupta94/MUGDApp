using Microsoft.WindowsAzure.MobileServices;
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
    public sealed partial class UserVoice : Page
    {
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
            items = await Table.ToCollectionAsync();
            //List<idea> ai = new List<idea>();
            //idea i = new idea();
            //i.Title = "Test";
            //i.option1 = "Hello1";
            //i.option2 = "Hello2";
            //i.option3 = "Hello3";
            //ai.Add(i);
            Voice.ItemsSource = items;
        }

        private async void Option1_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            idea i = temp.DataContext as idea;
            i.Countoption1++;
            await Table.UpdateAsync(i);
        }

        private async void Option2_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            idea i = temp.DataContext as idea;
            i.Countoption2++;
            await Table.UpdateAsync(i);
        }

        private async void Option3_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            idea i = temp.DataContext as idea;
            i.Countoption3++;
            await Table.UpdateAsync(i);
        }
    }
}
