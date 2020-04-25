using SoundScout.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoundScout
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // MainPage = new View.Matching(); USED THIS STATEMENT FOR DEBUGGING
            // WHILE COMMENTING THE BELOW ONE OUT
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
