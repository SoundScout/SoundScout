using System;
using System.Collections;
using Xamarin.Essentials;
using SoundScout.Model;
using SoundScout.Data;

namespace SoundScout.View
{
    // Strategy design class
    public class Matcher
    {
        public Matches matches;

        public Matcher()
        {
            matches = new Matches();
        }

        public int calcScore(string g1, string g2, string g3) { return generateScore(g1) + generateScore(g2) + generateScore(g3); }

        public int generateScore(string genre)
        {
            if (genre.Equals("rap"))
            {
                return 100;
            }
            else if (genre.Equals("classical"))
            {
                return 300;
            }
            else if (genre.Equals("jazz"))
            {
                return 400;
            }
            else if (genre.Equals("rock"))
            {
                return 500;
            }
            return 0;
        }
    }
    
    public class Iterator
    {
        public MyData data;
        public Matches m;
        public List<Matches> list;
        int curr;

        public Iterator()
        {
            this.data = new MyData();
            this.m = new Matches();
            this.list = this.data.Matches;
            this.curr = -1;
        }

        public bool hasNext()
        {
            bool hn = curr < list.Count ? true : false;
            return hn;
        }

        public object next()
        {
            curr++;
            return list[curr];
        }
    }

    // Iterator design class
    public class MatchHelper
    {
        // Compatibility value: ranging from -1 to 1
        public int compat;

        public MatchHelper(int soundScore)
        {
            this.soundScore = soundScore;
        }

        public int getCompat() { return compat; }
        public void setCompat(int newCompat) { compat = newCompat; }

        private void compare(int s1, int s2)
        {
            if (Math.Abs(s1 - s2) < 101)
            {
                // call this for both profiles maybe
                setCompat(1);
            }
            else if (Math.Abs(s1 - s2) > 100 && Math.Abs(s1 - s2) < 201)
            {
                setCompat(0);
            }
            else { setCompat(-1); }
        }

        private string Compatibility(int c1, int c2)
        {
            if (c1 + c2 == -2)
            {
                return "No Similarity";
            }
            else if (c1 + c2 == -1)
            {
                return "Low Similarity";
            }
            else if (c1 + c2 == 0)
            {
                return "High Similarity";
            }
            return null;
        }
    }
}
