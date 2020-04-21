using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Profile.ViewModel;
using Profile.ViewModel.Helpers;
using Xamarin.Forms;

namespace SoundScout.View
{
    public partial class ProfilePage : ContentPage
    {
        ProfileVM vm;
        public ProfilePage()
        {
            InitializeComponent();
            vm = Resources["vm"] as ProfileVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if(!Auth.IsAuthenticated())
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                vm.ReadInformation();
            }
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EditProfilePage());
        }
    }

    
}
