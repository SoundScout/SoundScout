using System;
using System.Collections.Generic;
using SoundScout.Model;

namespace SoundScout.Data
{
    public class MyData
    {
        public List<Matches> Matches = new List<Matches>()
        {
            new Matches()
            {
                mySoundScore = "100",
                soundScore = "100",
                genres = "rap",
                name = "Kirtland",
                phoneNumber = "5047231999",
            },
            new Matches()
            {
                mySoundScore = "100",
                soundScore = "300",
                genres = "classical",
                name = "Rashad",
                phoneNumber = "5047231999",

            },
            new Matches()
            {
                mySoundScore = "100",
                soundScore = "400",
                genres = "jazz",
                name = "Kirt",
                phoneNumber = "5047231999",
            },
            new Matches()
            {
                mySoundScore = "100",
                soundScore = "500",
                genres = "rock",
                name = "land",
                phoneNumber = "5047231999",
            },
        };
    }
}
