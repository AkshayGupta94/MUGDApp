using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MUGDApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class loginMember : Page
    {
        public loginMember()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog m = new MessageDialog("Ahhh... The Page is Under Construction");
            await m.ShowAsync();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UserId.Header = "User Id";
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Password.Header = "Password";
        }
    }
}
