using Hello_Earth_2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home
{
    internal class RegistrationViewModel
    {
        private string _email;
        private string _password;
        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }

        }
        private string _text;
        public string Text
        {
            get => _text;
            set => _text = value;

        }
        public ICommand RegistrationCommand { get; set; }
        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(() => RegistrateUser());
        }

        private async void RegistrateUser()
        {
            string token = await auth.RegisterWithEmailPassword(Email, Password);
            App.Current.MainPage.DisplayAlert("Hello",$"{ token}","ok");

        }
    }
}
