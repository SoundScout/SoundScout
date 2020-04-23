using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using SoundScout.Model;
using SoundScout.ViewModel.Helpers;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoundScout.iOS.Dependencies.Firestore))]
namespace SoundScout.iOS.Dependencies
{
    class Firestore : IFirestore
    {
        public Firestore()
        {

        }
        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("users");
                await collection.GetDocument(user.UserId).DeleteDocumentAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                var keys = new[]
            {
                new NSString("author"),
                new NSString("name"),
                new NSString("age"),
                new NSString("location"),
                new NSString("genre"),
                new NSString("phonenumber"),
            };
                var values = new NSObject[]
                {
                new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid),
                new NSString(user.Name),
                new NSNumber(user.Age),
                new NSString(user.Location),
                new NSString(user.Genre),
                new NSString(user.PhoneNumber),
                };

                var userDocument = new NSDictionary<NSString, NSObject>(keys, values);
                firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("users").AddDocument(userDocument);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IList<User>> ReadInformation()
        {
            try
            {
                var information = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("users");
                var query = information.WhereEqualsTo("author", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
                var documents = await query.GetDocumentsAsync();

                List<User> data = new List<User>();
                foreach (var doc in documents.Documents)
                {
                    var userData = doc.Data;
                    var info = new User
                    {
                        UserId = userData.ValueForKey(new NSString("author")) as NSString,
                        Name = userData.ValueForKey(new NSString("name")) as NSString,
                        Age = userData.ValueForKey(new NSString("age")) as NSString,
                        Location = userData.ValueForKey(new NSString("location")) as NSString,
                        Genre = userData.ValueForKey(new NSString("genre")) as NSString,
                        PhoneNumber = userData.ValueForKey(new NSString("phonenumber")) as NSString,
                    };
                    data.Add(info);
                }; 
                return data;
            }
            catch(Exception ex)
            {
                return new List<User>();
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                var keys = new[]
                {
                    new NSString("name"),
                    new NSString("age"),
                    new NSString("location"),
                    new NSString("genre"),
                    new NSString("phonenumber")
                };
                var values = new NSObject[]
                {
                    new NSString(user.Name),
                    new NSNumber(user.Age),
                    new NSString(user.Location),
                    new NSString(user.Genre),
                    new NSString(user.PhoneNumber)
                };
                var userDocument = new NSDictionary<NSObject, NSObject>(keys, values);
                var collection = Firebase.CloudFirestore.SharedInstance.GetCollection("users");
                await collection.GetDocument.(user.UserId).UpdateDataAsync(userDocument);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
