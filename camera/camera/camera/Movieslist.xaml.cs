using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Vision;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace camera
{
    public partial class Movieslist : ContentPage
    {
        

        public Movieslist()
        {
            InitializeComponent();
            Getmoviee();
        }

        private async Task Getmoviee()
        {
            HttpClient httpClient = new HttpClient();
            var show = await httpClient.GetStringAsync("http://picturer.azurewebsites.net/api/moviees1");
            var data = JsonConvert.DeserializeObject<List<Models.moviee>>(show);
            LvMovies.ItemsSource = data;
        }
    }
}
