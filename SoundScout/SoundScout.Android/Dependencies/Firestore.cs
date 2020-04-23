using Android.Gms.Tasks;
using SoundScout.Model;
using SoundScout.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoundScout.Droid.Dependencies.Firestore))]

namespace SoundScout.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<User> information;
        bool hasReadInformation = false;

        public Firestore()
        {
            information = new List<User>();
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
                collection.Document(user.UserId).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
                var userDocument = new Dictionary<string, Java.Lang.Object>
            {
                {"author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                {"name", user.Name },
                {"age", user.Age },
                {"location", user.Location },
                {"genre", user.Genre },
                {"phonenumber", user.PhoneNumber }
            };
                collection.Add(userDocument);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<IList<User>> ReadInformation()
        {
            hasReadInformation = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
            var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            query.Get().AddOnCompleteListener(this);

            for(int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadInformation)
                    break;
            }
            return information;
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
                collection.Document(user.UserId).Update("name", user.Name, "age", user.Age, "location", user.Location, "genre", user.Genre, "phonenumber", user.PhoneNumber);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;
                information.Clear();
                foreach (var doc in documents.Documents)
                {
                    User user = new User
                    {
                        Name = doc.Get("name").ToString(),
                        UserId = doc.Get("userID").ToString(),
                        Age = doc.Get("age").ToString(),
                        Location = doc.Get("location").ToString(),
                        Genre = doc.Get("favoriteGenre").ToString(),
                        PhoneNumber = doc.Get("phonenumber").ToString()
                    };
                    information.Add(user);
                }
            }
            else
            {
                information.Clear();
            }
            hasReadInformation = true;
        }

        
    }
}
