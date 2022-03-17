using Hello_Earth_2.Model;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home
{
    public class RegistrationParentViewModel
    {
        UserServiceImplementation userService;

        private string _userName;
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

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => _text = value;

        }
        public ICommand RegistrationCommand { get; set; }
        public RegistrationParentViewModel()
        {
            RegistrationCommand = new Command(() => RegistrateUser());
            userService = new UserServiceImplementation();
        }

        private async void RegistrateUser()
        {
            string token = await auth.RegisterWithEmailPassword(Email, Password);
            bool isSend = await auth.SendEmailVerification();
            if (isSend)
            {
                Parent parent = new Parent();
                parent.UserName = Email;
                parent.Role = Roles.PARENT;
                try
                {
                    await userService.createUser(parent);
                    App.Current.MainPage.DisplayAlert("Hello, Wysłano email", $"{ token}", "ok");
                }
                catch (Exception e)
                {
                    App.Current.MainPage.DisplayAlert("Sie wyjebał", $"{e.Message}", "ok");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Niet", $"{ token}", "ok");
            }

        }
    }
}
