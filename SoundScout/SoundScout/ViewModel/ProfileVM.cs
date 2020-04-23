using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SoundScout.Model;
using SoundScout.ViewModel.Helpers;

namespace SoundScout.ViewModel
{
    public class ProfileVM
    {
        public ObservableCollection<User> ProfileInformation { get; set; }
        public ProfileVM()
        {
            ProfileInformation = new ObservableCollection<User>();
        }
        public async void ReadInformation()
        {
            var information = await DatabaseHelper.ReadInformation();
            ProfileInformation.Clear();
            foreach(var i in information)
            {
                ProfileInformation.Add(i);
            }
        }
    }
}
