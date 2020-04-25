using System;
using Xamarin.Essentials;
namespace SoundScout.View
{
    public class Messaging
    {
        private String username;
        private String phoneNumber;
        public Messaging() { }
        public Messaging(String username, String phoneNumber)
        {
            this.username = username;
            this.phoneNumber = phoneNumber;

        }
        // getters and setters 
        public String getUsername() { return username; }
        public void setUsername(String newUsername) { username = newUsername; }
        public bool hasUsername() { if (username == null) { return false; } return true; }
        public String getPhoneNumber() { return phoneNumber; }
        public void setPhoneNumber(String newPhoneNumber) { phoneNumber = newPhoneNumber; }
        public bool hasPhoneNumber() { if (phoneNumber == null) { return false; } return true; }
        // sends sms message to matches user using their phone number
        public async void SendMsg()
        {
            Console.WriteLine("Messaging made it");
            String msgText = defaultMessage();
            String number = getPhoneNumber();
            try
            {
                var msg = new SmsMessage(msgText, number);
                await Sms.ComposeAsync(msg);
            }
            catch (FeatureNotSupportedException ex)
            {
            //    await App.Current.MainPage.DisplayAlert("Messaging Error", "Sms Messaging is Not Supported on Your Device", "OK");
            }
            catch (Exception ex)
            {
           //     await App.Current.MainPage.DisplayAlert("Unknown Error", "Restart and Try Again", "OK");

            }
        }
        // crafts a default message for the user to send.
        private String defaultMessage()
        {
            String message = "Hello, I am ," + getUsername() +
                ", We have matched on SoundScout!";
            return message;
        }
    }
}
