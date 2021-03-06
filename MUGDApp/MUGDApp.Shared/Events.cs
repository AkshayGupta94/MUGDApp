﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace MUGDApp
{
    class Events
    {

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        [JsonProperty(PropertyName = "containerName")]
        public string ContainerName { get; set; }

        [JsonProperty(PropertyName = "resourceName")]
        public string ResourceName { get; set; }

        [JsonProperty(PropertyName = "sasQueryString")]
        public string SasQueryString { get; set; }

        [JsonProperty(PropertyName = "imageUri")]
        public string imageUri { get; set; }

        public string type { get; set; }
        public string time { get; set; }
        public string url { get; set; }
        public string cost { get; set; }
        public string college { get; set; }
        public string issuedBy { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }

   


    }
        




   
    //class eventpg
    //{
    //    public BitmapImage bitmapImage { get; set; }
    //    public DateTime Date { get; set; }
    //    public string Title { get; set; }
    //    public string Desc { get; set; }

    //}
}
