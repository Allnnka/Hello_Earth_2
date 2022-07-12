using Hello_Earth_2.Model;
using Hello_Earth_2.Model.UserAuth;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
using Hello_Earth_2.View.ChildHome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;

namespace Hello_Earth_2.ViewModel.Home.RegistrationChild
{
    public class RegistrationChildViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _userName;
        private string _email;
        private string _password;
        private bool _isAnalyzing = false;
        private bool _isScanning = false;
        private bool _isScannerButton = true;
        private string _scanResult = string.Empty;

        bool _isRegisterForm = false;
        bool _isRegisterStatement = false;
        bool _isRegisterSuccess = false;
        bool _isAccepted = false;
        bool _isBackButtonVisible = true;


        private string _errorUserName;
        private string _errorEmail;
        private string _errorPassword;

        private bool _isErrorUserName;
        private bool _isErrorEmail;
        private bool _isErrorPassword;

        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
        UserServiceImplementation userService;
        FamilyServiceImplementation familyService;
        public ICommand EnableScannerCommand { get; set; }
        public ICommand FurtherCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand GoToAppCommand { get; set; }
        public RegistrationChildViewModel()
        {
            userService = new UserServiceImplementation();
            familyService = new FamilyServiceImplementation();
            EnableScannerCommand = new Command(() => EnableScannerHandler());
            FurtherCommand = new Command(() => FurtherFormHandler());
            BackCommand = new Command(() => BackFormHandler());
            RegisterCommand = new Command(() => RegistraterHandler());
            GoToAppCommand = new Command(() => GoToAppHandler());
        }


        public bool IsAnalyzing
        {
            get
            {
                return _isAnalyzing;
            }
            set
            {
                _isAnalyzing = value;
                OnPropertyChanged(nameof(IsAnalyzing));
            }
        }
        public bool IsScanning
        {
            get
            {
                return _isScanning;
            }
            set
            {
                _isScanning = value;
                OnPropertyChanged(nameof(IsScanning));
            }
        }

        public bool IsRegisterForm
        {
            get
            {
                return _isRegisterForm;
            }
            set
            {
                _isRegisterForm = value;
                OnPropertyChanged(nameof(IsRegisterForm));
            }
        }
        public bool IsBackButtonVisible
        {
            get
            {
                return _isBackButtonVisible;
            }
            set
            {
                _isBackButtonVisible = value;
                OnPropertyChanged(nameof(IsBackButtonVisible));
            }
        }

        public bool IsRegisterStatement
        {
            get
            {
                return _isRegisterStatement;
            }
            set
            {
                _isRegisterStatement = value;
                OnPropertyChanged(nameof(IsRegisterStatement));
            }
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
        public bool IsAccepted
        {
            get
            {
                return _isAccepted;
            }
            set
            {
                _isAccepted = value;
                OnPropertyChanged(nameof(IsAccepted));
            }
        }
        public bool IsRegisterSuccess
        {
            get
            {
                return _isRegisterSuccess;
            }
            set
            {
                _isRegisterSuccess = value;
                OnPropertyChanged(nameof(IsRegisterSuccess));
            }
        }

        public bool IsScannerButton
        {
            get
            {
                return _isScannerButton;
            }
            set
            {
                _isScannerButton = value;
                OnPropertyChanged(nameof(IsScannerButton));
            }
        }

        public string ScanResult
        {
            get
            {
                return _scanResult;
            }
            set
            {
                _scanResult = value;
                OnPropertyChanged(nameof(ScanResult));
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
                Child child = new Child();
                child.Email = Email;
                child.UserName = UserName;
                child.Role = Roles.CHILD;
                child.FamilyId = ScanResult;
                await userService.CreateUser(child, userAuth.Uid);
                child.FamilyId = null;
                child.Uid = userAuth.Uid;
                await familyService.AddChildToFamily(child, ScanResult);
                IsRegisterStatement = false;
                IsRegisterSuccess = true;
                IsBackButtonVisible = false;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Equals("The email address is badly formatted."))
                {
                    ErrorEmail = "Nieprawidłowy format adresu e-mail";
                    IsErrorEmail = true;
                }
                else if (ex.Message.ToString().Equals("The given password is invalid. [ Password should be at least 6 characters ]"))
                {
                    ErrorPassword = "Hasło jest zbyt krótkie. Powinno zawierać conajmniej 6 znaków";
                    IsErrorPassword = true;
                }
                else if (ex.Message.ToString().Equals("The email address is already in use by another account."))
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
                IsRegisterStatement = false;
            }
        }
        private void EnableScannerHandler()
        {
            IsScannerButton = false;
            IsScanning = true;
        }
        public void OnScanComplete(string scannedCode)
        {
            ScanResult = scannedCode;
            IsScanning = false;
            IsRegisterForm = true;
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
                    IsRegisterStatement = true;
                }
            }
        }

        private async void BackFormHandler()
        {
            if (IsRegisterForm)
            {
                IsRegisterForm = false;
                IsScannerButton = true;
            }
            else if (IsRegisterStatement)
            {
                IsRegisterForm = true;
                IsRegisterStatement = false;
            }
            else
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
        private void GoToAppHandler()
        {
            App.Current.MainPage = new NavigationPage(new ChildHomePage());
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
