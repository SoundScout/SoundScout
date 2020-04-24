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
        User user = firebase.auth().currentUser;
        public ObservableCollection<string> ProfileInformation { get; set; }
        
        public ProfileVM()
        {
            ProfileInformation = new ObservableCollection<string>();
        }
        
        public async bool ReadInformation(User user)
        {
            if(user != null)
            {
                var information = await DatabaseHelper.ReadInformation(user);
                ProfileInformation.Clear();
                foreach(string i in information)
                {
                    ProfileInformation.Add(i);
                }
                return true;
            }
            else { return false };
        }
    }
}
