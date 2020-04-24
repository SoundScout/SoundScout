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
        private int age;
        private string location;
        private string favoriteGenre;
        private string phoneNumber;

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                Name = user.Name;
                age = user.Age;
                location = user.Location;
                favoriteGenre = user.Genre;
                phoneNumber = user.PhoneNumber;
                OnPropertyChanged("User");
            }
        }
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                User.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("User");
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                User.Age = age;
                OnPropertyChanged("Age");
                OnPropertyChanged("User");
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
                User.Location = location;
                OnPropertyChanged("Location");
                OnPropertyChanged("User");
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
                User.Genre = favoriteGenre;
                OnPropertyChanged("Genre");
                OnPropertyChanged("User");
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
                User.PhoneNumber = phoneNumber;
                OnPropertyChanged("Phone Number");
                OnPropertyChanged("User");
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
            bool result = await DatabaseHelper.UpdateUser(User);
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
