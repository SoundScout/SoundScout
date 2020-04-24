using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using SoundScout.Model;
using SoundScout.ViewModel.Helpers;
using Xamarin.Forms;

namespace SoundScout.ViewModel
{
    public class EditProfileVM : INotifyPropertyChanged
    {
        private User user;
        private string name;
        private string age;
        private string location;
        private string favoriteGenre;
        private string phoneNumber;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        public string Genre
        {
            get
            {
                return favoriteGenre;
            }
            set
            {
                favoriteGenre = value;
                OnPropertyChanged("Genre");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("Phone Number");
            }
        }

        public ICommand UpdateCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public EditProfileVM()
        {
            UpdateCommand = new Command(Update, UpdateCanExecute);
        }

        private bool UpdateCanExecute(object obj)
        {
            return !string.IsNullOrEmpty(Name);
        }
        
        private async void UpdateProfile(object obj)
        {
            bool result = await DatabaseHelper.UpdateUser(new Model.User
            {
               Name = Name,
               Age = Age,
               Location = Location,
               Genre = Genre, 
               PhoneNumber = PhoneNumber 
            });
            if (result) {
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else {
                await App.Current.MainPage.DisplayAlert("Error!", "There was an error, please try again", "Okay");
            }
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
