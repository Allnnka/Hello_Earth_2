using Hello_Earth_2.Model;
using Hello_Earth_2.Model.UserAuth;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
using Hello_Earth_2.View.ConfigurationParent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        UserServiceImplementation userService;
        private bool _isRegistrationParent = false;
        private bool _isRegistrationChild = false;
        private bool _isLogin = true;
        private bool _isRegister = false;
        private bool _isRegisterOpen = false;
        private bool _isHomeOpen = true;
        private bool _isRegistrationParentSuccess = false;
        private string _emailLogin;
        private string _passwordLogin;
        private string _userName;
        private string _email;
        private string _password;

        private bool _isFormParent = true;
        private bool _isFurtherParent = false;
        private bool _isAccepted = false;

        private Color _loginColor = (Color)Application.Current.Resources["PrimaryColor"];
        private Color _registrationColor = (Color)Application.Current.Resources["DisableTextColor"];
        private Color _playerButtonColor = (Color)Application.Current.Resources["ThirdyColor"];
        private Color _parentButtonColor = (Color)Application.Current.Resources["SecondaryColor"];

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ParentCommand { get; set; }
        public ICommand PlayerCommand { get; set; }
        public ICommand LoginFormCommand { get; set; }
        public ICommand RegistrationFormCommand { get; set; }
        public ICommand FurtherCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand GoToAppCommand { get; set; }
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

        public bool IsFormParent
        {
            get { return _isFormParent; }
            set
            {
                _isFormParent = value;
                OnPropertyChanged(nameof(IsFormParent));
            }
        }

        public bool IsFurtherParent
        {
            get { return _isFurtherParent; }
            set
            {
                _isFurtherParent = value;
                OnPropertyChanged(nameof(IsFurtherParent));
            }
        }

        public bool IsAcctepted
        {
            get { return _isAccepted; }
            set
            {
                _isAccepted = value;
                OnPropertyChanged(nameof(IsAcctepted));
            }
        }
        
        public bool IsRegistrationParent
        { 
            get { return _isRegistrationParent; }
            set { 
                _isRegistrationParent = value;
                OnPropertyChanged(nameof(IsRegistrationChild));
            } 
        }
        public bool IsRegistrationChild
        {
            get { return _isRegistrationChild; }
            set { 
                _isRegistrationChild = value;
                OnPropertyChanged(nameof(IsRegistrationChild));
            }
        }
        public bool IsLogin
        {
            get { return _isLogin; }
            set { 
                _isLogin = value;
                OnPropertyChanged(nameof(IsLogin));
            }
        }
        public bool IsRegister
        {
            get { return _isRegister; }
            set
            {
                _isRegister = value;
                OnPropertyChanged(nameof(IsRegister));
            }
        }

        public bool IsRegisterOpen
        {
            get { return _isRegisterOpen; }
            set
            {
                _isRegisterOpen = value;
                OnPropertyChanged(nameof(IsRegisterOpen));
            }
        }

        public bool IsHomeOpen
        {
            get { return _isHomeOpen; }
            set
            {
                _isHomeOpen = value;
                OnPropertyChanged(nameof(IsHomeOpen));
            }
        }

        public bool IsRegistrationParentSuccess
        {
            get { return _isRegistrationParentSuccess; }
            set
            {
                _isRegistrationParentSuccess = value;
                OnPropertyChanged(nameof(IsRegistrationParentSuccess));
            }
        }

        public Color LoginColor
        {
            get { return _loginColor; }
            set {
                _loginColor = value;
                OnPropertyChanged(nameof(LoginColor));
            }
        }

        public Color RegistrationColor
        {
            get { return _registrationColor; }
            set {
                _registrationColor = value;
                OnPropertyChanged(nameof(RegistrationColor)); 
            }
        }

        public Color PlayerButtonColor
        {
            get { return _playerButtonColor; }
            set
            {
                _playerButtonColor = value;
                OnPropertyChanged(nameof(PlayerButtonColor));
            }
        }

        public Color ParentButtonColor
        {
            get { return _parentButtonColor; }
            set
            {
                _parentButtonColor = value;
                OnPropertyChanged(nameof(ParentButtonColor));
            }
        }

        public string EmailLogin
        {
            get { return _emailLogin; }
            set { _emailLogin = value; }
        }

        public string PasswordLogin
        {
            get { return _passwordLogin; }
            set { _passwordLogin = value;}
        }


        public HomeViewModel()
        {
            userService = new UserServiceImplementation();
            ParentCommand = new Command(()=> RegistrationParentHandler());
            PlayerCommand = new Command(()=> RegistrationChildHandler());
            LoginFormCommand = new Command(()=> LoginFormHandler());
            RegistrationFormCommand = new Command(() => RegistrationFormHandler());
            FurtherCommand = new Command(() => FurtherFormHandler());
            BackCommand = new Command(() => BackHandler());
            GoToAppCommand = new Command(() => GoToAppHandler());
        }

        private void RegistrationParentHandler()
        {
            IsRegistrationParent = !IsRegistrationParent;
            ParentButtonColor = (Color)Application.Current.Resources["PrimaryColor"];
            PlayerButtonColor = (Color)Application.Current.Resources["ThirdyColor"];
        }

        private void RegistrationChildHandler()
        {
            IsRegistrationChild =!IsRegistrationChild;
            PlayerButtonColor = (Color)Application.Current.Resources["PrimaryColor"];
            ParentButtonColor = (Color)Application.Current.Resources["SecondaryColor"];
        }

        private void GoToAppHandler()
        {
            IsLogin = true;
            IsRegister = false;
            IsRegistrationParentSuccess = false;
        }

        private void LoginFormHandler()
        {
            IsLogin = true;
            IsRegister = false;
            LoginColor = (Color)Application.Current.Resources["PrimaryColor"];
            RegistrationColor = (Color)Application.Current.Resources["DisableTextColor"];
        }

        private void RegistrationFormHandler()
        {
            IsLogin = false;
            IsRegister = true;
            RegistrationColor = (Color)Application.Current.Resources["PrimaryColor"];
            LoginColor = (Color)Application.Current.Resources["DisableTextColor"];
        }

        private void FurtherFormHandler()
        {
            if(IsRegister && IsRegistrationParent)
            {
                IsRegisterOpen = true;
                IsHomeOpen = false;
                IsRegister = false;
            }
            else if (IsFurtherParent && IsRegisterOpen)
            {
                RegistrateUser();
            }
            else if (IsRegisterOpen)
            {
                IsFormParent = false;
                IsAcctepted = false;
                IsFurtherParent = true;
            }else
            {
                LoginHandler();
            }
        }


        private async void LoginHandler()
        {
            try
            {
                UserAuth userAuth = await auth.LoginWithEmailPassword(EmailLogin, PasswordLogin);
                App.Current.MainPage = new NavigationPage(new ConfigurationParentPage());
            }catch{
                await App.Current.MainPage.DisplayAlert("Uwaga!","Nieprawidłowy login lub hasło", "ok");
            }
            
        }

        private void BackHandler()
        {
            if (IsFurtherParent)
            {
                IsFormParent = true;
                IsAcctepted = false;
                IsFurtherParent = false;
            }
            else if (IsRegistrationParentSuccess)
            {
                IsRegistrationParent = false;
                IsRegistrationParentSuccess = false;
                IsHomeOpen = true;
                LoginFormHandler();
            }
            else if (IsFormParent)
            {
                IsRegisterOpen = false;
                IsHomeOpen = true;
                IsRegister = true;
            }
            /*else if (IsFurtherParent)
            {
                IsFormParent = true;
                IsFurtherParent = false;
            }
            else
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }*/
        }
        private async void RegistrateUser()
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
                    await userService.CreateUser(parent,userAuth.Uid);
                    IsFurtherParent = false;
                    IsRegisterOpen=false;
                    IsRegistrationParentSuccess = true;
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
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
