using Hello_Earth_2.Model;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
using Hello_Earth_2.View.Home;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home
{
    public class RegistrationParentViewModel : INotifyPropertyChanged
    {
        UserServiceImplementation userService;

        private string _userName;
        private string _email;
        private string _password;

        private bool _isForm = true;
        private bool _isFurther = false;
        private bool _isAccepted = false;
        public event PropertyChangedEventHandler PropertyChanged;
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

        public bool IsForm
        {
            get { return _isForm; }
            set { 
                _isForm = value;
                OnPropertyChanged(nameof(IsForm));
            }
        }

        public bool IsFurther
        {
            get { return _isFurther; }
            set { 
                _isFurther = value;
                OnPropertyChanged(nameof(IsFurther));
            }
        }

        public bool IsAcctepted
        {
            get { return _isAccepted; }
            set { 
                _isAccepted = value;
                OnPropertyChanged(nameof(IsAcctepted));
            }
        }
        public ICommand RegistrationCommand { get; set; }
        public ICommand FurtherCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public RegistrationParentViewModel()
        {
            RegistrationCommand = new Command(() => RegistrateUser());
            FurtherCommand = new Command(() => FurtherHandler());
            BackCommand = new Command(() => BackHandler());
            userService = new UserServiceImplementation();
        }

        private void FurtherHandler()
        {
            IsForm = false;
            IsAcctepted = false;
            IsFurther = true;
        }
        private async void BackHandler()
        {
            if (IsFurther)
            {
                IsForm = true;
                IsFurther = false;
            }
            else
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
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
                    App.Current.MainPage.DisplayAlert("Oppss, coś poszło nie tak", $"{e.Message}", "ok");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Niet", $"{ token}", "ok");
            }

        }
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
