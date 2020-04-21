using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Profile.Model;
using Xamarin.Forms;

namespace SoundScout.ViewModel.Helpers
{
    public interface IFirestore
    {
        bool InsertUser(User user);
        Task<bool> DeleteUser(User user);
        Task<bool> UpdateUser(User user);
        Task<IList<User>> ReadInformation();
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
        public static Task<IList<User>> ReadInformation()
        {
            return firestore.ReadInformation();
        }
        public static Task<bool> UpdateUser(User user)
        {
            return firestore.UpdateUser(user);
        }
    }
}