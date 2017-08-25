using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Vision;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace camera
{
    public partial class MainPage : ContentPage
    {
        private string emotionKey;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnImage_OnClicked(object sender, EventArgs e)
        {
            LblResult.Text = "";
            var emotionKey = "3ea63bdad6ec41659989eaa0d260a73b";
               var media = Plugin.Media.CrossMedia.Current;

            await media.Initialize();
            var file = await CrossMedia.Current.PickPhotoAsync();
           // var file = await media.TakePhotoAsync(new StoreCameraMediaOptions { SaveToAlbum = false });
            if (file !=null)
            {
                Img.Source=ImageSource.FromStream(()=>file.GetStream());
                var emotionclient=new EmotionServiceClient(emotionKey);
                var result = await emotionclient.RecognizeAsync(file.GetStream());
                var score = result.FirstOrDefault().Scores.ToRankedList().First().Key;
                LblResult.Text = $"Emotion is {score}";
                file.Dispose();
            }
            
        }
    }
}
