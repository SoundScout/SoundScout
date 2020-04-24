using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SoundScout.Model;
using Xamarin.Forms;

namespace SoundScout.ViewModel.Helpers
{
    public interface IFirestore
    {
        bool InsertUser(User user);
        Task<bool> DeleteUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> ReadInformation(User user);
    }

    public class DatabaseHelper
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static Task<bool> DeleteUser(User user)
        {
            return firestore.DeleteUser(user);
        }
        public static bool InsertUser(User user)
        {
            return firestore.InsertUser(user);
        }
        public static Task<bool> ReadInformation(User user)
        {
            return firestore.ReadInformation(user);
        }
        public static Task<bool> UpdateUser(User user)
        {
            return firestore.UpdateUser(user);
        }
    }
}
