using System;
using System.Collections.ObjectModel;
using SoundScout.Data;
using SoundScout.Model;

namespace SoundScout.ViewModel
{
    public class MatchesViewModel
    {
        private ObservableCollection<Matches> matches;
        public MatchesViewModel()
        {
            Matches = new ObservableCollection<Matches>();
            MyData context = new MyData();
            foreach(var m in context.Matches)
            {
                Matches.Add(m);
            }
        }
        public ObservableCollection<Matches> Matches
        {
            get
            {
                return matches;
            }

            set
            {
                matches = value;
            }
        }
    }
}
