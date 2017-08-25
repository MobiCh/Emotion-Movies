using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace camera
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new camera.Directive()
            {
                BarBackgroundColor = Color.FromHex("#C0C0C0"),
                BarTextColor = Color.Black
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
