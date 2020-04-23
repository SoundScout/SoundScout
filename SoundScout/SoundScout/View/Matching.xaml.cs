using System;
using System.Collections.Generic;
using SoundScout.Model;
using SoundScout.ViewModel;
using Xamarin.Forms;

namespace SoundScout.View
{
    public partial class Matching : ContentPage
    {
        public Matching()
        {
            InitializeComponent();
            BindingContext = new MatchesViewModel();

        }
        void Messaging(object sender,SelectedItemChangedEventArgs e)
        {
            Matches item = e.SelectedItem as Matches;
            Messaging msg = new Messaging(item.name, item.phoneNumber);
            msg.SendMsg();
        }
    }
}
