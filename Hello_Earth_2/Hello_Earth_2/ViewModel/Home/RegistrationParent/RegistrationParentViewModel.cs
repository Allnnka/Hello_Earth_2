using Hello_Earth_2.Model;
using Hello_Earth_2.Model.UserAuth;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home.RegistrationParent
{
    public class RegistrationParentViewModel : INotifyPropertyChanged
    {
        UserServiceImplementation userService;
        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
        private string _userName;
        private string _email;
        private string _password;
        public event PropertyChangedEventHandler PropertyChanged;

        bool _isRegisterForm = true;
        bool _isRegisterStatement = false;
        bool _isRegisterSuccess = false;
        bool _isAccepted = false;

        public ICommand FurtherCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand BackToLoginCommand { get; set; }
        public RegistrationParentViewModel()
        {
            userService = new UserServiceImplementation();
            FurtherCommand = new Command(() => FurtherFormHandler());
            BackCommand = new Command(() => BackHandler());
            RegisterCommand = new Command(() => RegistraterHandler());
            BackToLoginCommand = new Command(() => BackToLoginHandler());
        }

        public bool IsRegisterForm{
            get{
                return _isRegisterForm;
            }
            set {
                _isRegisterForm = value;
                OnPropertyChanged(nameof(IsRegisterForm));
            }
        }

        public bool IsRegisterSatement {
            get { 
                return _isRegisterStatement;
            } 
            set { 
                _isRegisterStatement = value;
                OnPropertyChanged(nameof(IsRegisterSatement));
            }
        }

        public bool IsRegisterSuccess {
            get {
                return _isRegisterSuccess;
            } 
            set { 
                _isRegisterSuccess = value;
                OnPropertyChanged(nameof(IsRegisterSuccess));
            }
        }

        public bool IsAccepted {
            get{
                return _isAccepted;
            }
            set {
                _isAccepted = value;
                OnPropertyChanged(nameof(IsAccepted));
            } 
        }

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

        private async void RegistraterHandler()
        {
            UserAuth userAuth = await auth.RegisterWithEmailPassword(Email, Password);
            bool isSend = await auth.SendEmailVerification();
            if (isSend)
            {
                Parent parent = new Parent();
                parent.UserName = UserName;
                parent.Email = Email;
                parent.Role = Roles.PARENT;
                try
                {
                    await userService.CreateUser(parent, userAuth.Uid);
                    IsRegisterSatement = false;
                    IsRegisterSuccess = true;
                }
                catch (Exception e)
                {
                    App.Current.MainPage.DisplayAlert("Oppss, coś poszło nie tak", $"{e.Message}", "ok");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Niet", $"Coś poszło nie tak", "ok");
            }

        }

        private void FurtherFormHandler()
        {
            if (_isRegisterForm)
            {
                IsRegisterForm = false;
                IsRegisterSatement = true;
            }
        }

        private async void BackHandler()
        {
            if (IsRegisterForm)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                IsRegisterSatement = false;
                IsRegisterForm = true;
            }
        }

        private async void BackToLoginHandler()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
