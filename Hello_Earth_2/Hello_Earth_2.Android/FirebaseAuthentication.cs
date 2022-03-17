using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hello_Earth_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Xamarin.Forms;
using Hello_Earth_2.Droid;
using Firebase.Auth;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace Hello_Earth_2.Droid
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance?.SignInWithEmailAndPasswordAsync(email, password);
            var token = user.User.GetIdToken(false);
            return token.ToString();
        }

        public async Task<string> RegisterWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = user.User.GetIdToken(false);
            return token.ToString();
        }

        public async Task<bool> SendEmailVerification()
        {
            try
            {
                var user = FirebaseAuth.Instance.CurrentUser;
                ActionCodeSettings actionCodeSettings = ActionCodeSettings.NewBuilder().SetUrl("https://helloearth2-5887b.firebaseapp.com").Build();
                await user.SendEmailVerificationAsync(actionCodeSettings);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}