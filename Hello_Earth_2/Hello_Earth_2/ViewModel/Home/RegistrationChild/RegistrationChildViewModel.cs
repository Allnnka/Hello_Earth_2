using Hello_Earth_2.Model;
using Hello_Earth_2.Model.UserAuth;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
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
        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
        UserServiceImplementation userService;
        FamilyServiceImplementation familyService;
        public ICommand EnableScannerCommand { get; set; }
        public ICommand FurtherCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public RegistrationChildViewModel()
        {
            userService = new UserServiceImplementation();
            familyService = new FamilyServiceImplementation();
            EnableScannerCommand = new Command(() => EnableScannerHandler());
            FurtherCommand = new Command(() => FurtherFormHandler());
            BackCommand = new Command(() => BackFormHandler());
            RegisterCommand = new Command(() => RegistraterHandler());
        }
        public bool IsAnalyzing { 
            get { 
                return _isAnalyzing; 
            }
            set {
                _isAnalyzing = value;
                OnPropertyChanged(nameof(IsAnalyzing));
            }
        }
        public bool IsScanning {
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
                _isScannerButton= value;
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
        private async void RegistraterHandler()
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
            if (_isRegisterForm)
            {
                IsRegisterForm = false;
                IsAccepted = false;
                IsRegisterStatement = true;
            }
        }

        private async void BackFormHandler()
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
