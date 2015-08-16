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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MUGDApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class eventDetailxaml : Page
    {
         Events info1;
        public eventDetailxaml()
        {
            this.InitializeComponent();
           
        }
        int f = 0;
        EventDetail a = new EventDetail();
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {

                info1 = e.Parameter as Events;
                a.Desc = info1.Desc;
                a.Title = info1.Title;
                a.college = info1.college;
                a.date = info1.Date.Date.ToString("dd/MM/yyyy");
                a.bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(info1.ImageUri));
                image2.Source = a.bitmapImage;
                a.issuedBy = info1.issuedBy;
                a.url = info1.url;
                a.mobile = info1.mobile;
                a.Email = info1.email;

            }
            catch (Exception e1)
            {
                f = 1;
            }
            finally
            {
                if (f == 1)
                {
                    MessageDialog m = new MessageDialog("Oops... There was some Problem Handling your Request");
                    await m.ShowAsync();

                }
                else
                {
                    Pivott.DataContext = a;
                }
            }
        }
    }
}
