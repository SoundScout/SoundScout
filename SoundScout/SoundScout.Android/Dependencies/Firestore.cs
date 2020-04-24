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
        List<string> information;
        bool hasReadInformation = false;

        public Firestore()
        {
            information = new List<string>();
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
                collection.Document(user.Uid).Delete();
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
                {"name", user.Name },
                {"age", user.Age },
                {"location", user.Location },
                {"favoriteGenre", user.Genre },
                {"phoneNumber", user.PhoneNumber },
                {"email", user.Email },
                {"password", user.Password },
                {"uid", user.Uid }
            };
                collection.Add(userDocument);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> ReadInformation()
        {
            hasReadInformation = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
            var query = collection.WhereEqualTo("uid", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
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
                        PhoneNumber = doc.Get("phoneNumber").ToString(),
                        Email = doc.Get("email").ToString(),
                        Password = doc.Get("password").ToString(),
                        Uid = doc.Get("uid").ToString()
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
