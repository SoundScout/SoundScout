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
        public ObservableCollection<string> ProfileInformation { get; set; }
        
        public ProfileVM()
        {
            ProfileInformation = new ObservableCollection<string>();
        }
        
        public async Task<bool> ReadInformation()
        {
            var information = await DatabaseHelper.ReadInformation();
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
