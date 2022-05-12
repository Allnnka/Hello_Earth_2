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

        private string _errorUserName;
        private string _errorEmail;
        private string _errorPassword;

        private bool _isErrorUserName;
        private bool _isErrorEmail;
        private bool _isErrorPassword;

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

        public string ErrorUserName
        {
            get
            {
                return _errorUserName;
            }
            set
            {
                _errorUserName = value;
                OnPropertyChanged(nameof(ErrorUserName));
            }
        }

        public string ErrorEmail
        {
            get
            {
                return _errorEmail;
            }
            set
            {
                _errorEmail = value;
                OnPropertyChanged(nameof(ErrorEmail));
            }
        }
        public string ErrorPassword
        {
            get
            {
                return _errorPassword;
            }
            set
            {
                _errorPassword = value;
                OnPropertyChanged(nameof(ErrorPassword));
            }
        }

        public bool IsErrorUserName
        {
            get
            {
                return _isErrorUserName;
            }
            set
            {
                _isErrorUserName = value;
                OnPropertyChanged(nameof(IsErrorUserName));
            }
        }

        public bool IsErrorPassword
        {
            get
            {
                return _isErrorPassword;
            }
            set
            {
                _isErrorPassword = value;
                OnPropertyChanged(nameof(IsErrorPassword));
            }
        }

        public bool IsErrorEmail
        {
            get
            {
                return _isErrorEmail;
            }
            set
            {
                _isErrorEmail = value;
                OnPropertyChanged(nameof(IsErrorEmail));
            }
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
            set { _email = value; IsErrorEmail = false; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; IsErrorPassword = false; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; IsErrorUserName = false; }
        }

        public Color RegistrationColor
        {
            get { return (Color)Application.Current.Resources["PrimaryColor"]; }
            private set { }
        }
        public Color LoginColor
        {
            get { return (Color)Application.Current.Resources["DisableTextColor"]; }
            private set { }
        }

        private async void RegistraterHandler()
        {
            try
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
                        auth.SignOut();
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
            } catch (Exception ex)
            {
                if(ex.Message.ToString().Equals("The email address is badly formatted."))
                {
                    ErrorEmail = "Nieprawidłowy format adresu e-mail";
                    IsErrorEmail = true;
                }else if(ex.Message.ToString().Equals("The given password is invalid. [ Password should be at least 6 characters ]"))
                {
                    ErrorPassword = "Hasło jest zbyt krótkie. Powinno zawierać conajmniej 6 znaków";
                    IsErrorPassword = true;
                }else if(ex.Message.ToString().Equals("The email address is already in use by another account."))
                {
                    ErrorEmail = "Ten adres e-mail jest już używany";
                    IsErrorEmail = true;
                }
                else
                {
                    ErrorEmail = "Wystąpił nieoczekiwany błąd. Sprawdź dane oraz połączenie z internetem, a następnie spróbuj ponownie.";
                    IsErrorEmail = true;
                }
                IsRegisterForm = true;
                IsAccepted = false;
                IsRegisterSatement = false;
            }
        }

        private void FurtherFormHandler()
        {
            if (String.IsNullOrEmpty(UserName))
            {
                ErrorUserName = "Nazwa użytkownika nie może być pusta";
                IsErrorUserName = true;
            }
            else if (String.IsNullOrEmpty(Email))
            {
                ErrorEmail = "Adres e-mail nie może być pusty";
                IsErrorEmail = true;
            }
            else if (String.IsNullOrEmpty(Password))
            {
                ErrorPassword = "Hasło nie może być puste";
                IsErrorPassword = true;
            }
            else
            {
                if (_isRegisterForm)
                {
                    IsRegisterForm = false;
                    IsAccepted = false;
                    IsRegisterSatement = true;
                }
            }
        }

        private async void BackHandler()
        {
            if (IsRegisterSatement)
            {
                IsRegisterForm = true;
                IsRegisterSatement = false;
            }
            else
            {
                await Application.Current.MainPage.Navigation.PopAsync();
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
