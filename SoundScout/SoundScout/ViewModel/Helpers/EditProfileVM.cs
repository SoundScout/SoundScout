using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SoundScout.ViewModel.Helpers
{
    public class EditProfileVM : INotifyPropertyChanged
    {
        private string userID;
        private string name;
        private int age;
        private string location;
        private string favoriteGenre;
        private string phoneNumber;

        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
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
                OnPropertyChanged("Name");
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

        public ICommand SaveProfileCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public EditProfileVM()
        {
            SaveProfileCommand = new Command(SaveProfile, SaveProfileCanExecute);
        }

        private bool SaveProfileCanExecute(object obj)
        {
            return !string.IsNullOrEmpty(Name);
        }
        private void SaveProfile(object obj)
        {
            bool result = DatabaseHelper.InsertUser(new Model.User
            {
                UserId = Auth.GetCurrentUserId(),
                Name = name,
                Age = age,
                Location = location,
                Genre = favoriteGenre,
                PhoneNumber = phoneNumber
            });
            if(result)
            {
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong.", "Okay");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
