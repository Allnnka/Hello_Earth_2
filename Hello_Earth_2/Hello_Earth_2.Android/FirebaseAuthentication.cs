﻿using Android.App;
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
using Hello_Earth_2.Model.UserAuth;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace Hello_Earth_2.Droid
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public async Task<UserAuth> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance?.SignInWithEmailAndPasswordAsync(email, password);
                UserAuth userAuth = new UserAuth();
                userAuth.Uid = user.User.Uid;
                userAuth.IsEmailVerified = user.User.IsEmailVerified;
                return userAuth;
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task<UserAuth> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                UserAuth userAuth = new UserAuth();
                userAuth.Uid = user.User.Uid;
                userAuth.IsEmailVerified = user.User.IsEmailVerified;
                return userAuth;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SignOut()
        {
            FirebaseAuth.Instance.SignOut();
        }
        public UserAuth GetUserAuth()
        {
            try
            {
                var user = FirebaseAuth.Instance.CurrentUser;
                UserAuth userAuth = new UserAuth
                {
                    Uid = user.Uid,
                    IsEmailVerified = user.IsEmailVerified
                };
                return userAuth;
            }catch(Exception ex)
            {
                return null;
            }
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