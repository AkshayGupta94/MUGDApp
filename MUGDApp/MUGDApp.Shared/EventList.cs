using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace MUGDApp
{
    class EventList
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string type { get; set; }
        public string college { get; set; }
        public string issuedBy { get; set; }
        public string date { get; set; }
        public BitmapImage bitmapImage { get; set; }
        public string back{ get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }
}
