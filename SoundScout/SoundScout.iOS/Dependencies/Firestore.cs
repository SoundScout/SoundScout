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
                new NSString("name"),
                new NSString("age"),
                new NSString("location"),
                new NSString("genre"),
                new NSString("phonenumber"),
                new NSString("email"),
                new NSString("password"),
                new NSString("uid")
            };
                var values = new NSObject[]
                {
                new NSString(user.Name),
                new NSString(user.Age),
                new NSString(user.Location),
                new NSString(user.Genre),
                new NSString(user.PhoneNumber),
                new NSString(user.Email),
                new NSString(user.Password),
                new NSString(user.Uid)
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

        public async bool ReadInformation()
        {
            try
            {
                var information = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("users");
                var query = information.WhereEqualsTo("uid", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
                var documents = await query.GetDocumentsAsync();

                List<string> data = new List<string>();
                foreach (var doc in documents.Documents)
                {
                    var userData = doc.Data;
                    var info = new User
                    {
                        Name = userData.ValueForKey(new NSString("name")) as NSString,
                        Age = userData.ValueForKey(new NSString("age")) as NSString,
                        Location = userData.ValueForKey(new NSString("location")) as NSString,
                        Genre = userData.ValueForKey(new NSString("genre")) as NSString,
                        PhoneNumber = userData.ValueForKey(new NSString("phonenumber")) as NSString,
                        Email = userData.ValueForKey(new NSString("email")) as NSString,
                        Password = userData.ValueForKey(new NSString("password")) as NSString,
                        Uid = userData.ValueForKey(new NSString("uid")) as NSString,
                    };
                    data.Add(info);
                }; 
                return data;
            }
            catch(Exception ex)
            {
                return new List<string>();
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
                    new NSString("email"),
                    new NSString("password"),
                    new NSString("uid")
                };
                var values = new NSObject[]
                {
                    new NSString(user.Name),
                    new NSNumber(user.Age),
                    new NSString(user.Location),
                    new NSString(user.Genre),
                    new NSString(user.PhoneNumber)
                    new NSString(user.Email),
                    new NSString(user.Password),
                    new NSString(user.Uid)
                };
                var userDocument = new NSDictionary<NSObject, NSObject>(keys, values);
                var collection = Firebase.CloudFirestore.SharedInstance.GetCollection("users");
                await collection.GetDocument(user.Uid).UpdateDataAsync(userDocument);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
