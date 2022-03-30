using Hello_Earth_2.Model;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
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
        private string _emailLogin;
        private string _passwordLogin;
        private string _userName;
        private string _email;
        private string _password;

        private bool _isForm = true;
        private bool _isFurther = false;
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
            set
            {
                _isForm = value;
                OnPropertyChanged(nameof(IsForm));
            }
        }

        public bool IsFurther
        {
            get { return _isFurther; }
            set
            {
                _isFurther = value;
                OnPropertyChanged(nameof(IsFurther));
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
            ParentCommand = new Command(()=> RegistrationParentHandler());
            PlayerCommand = new Command(()=> RegistrationChildHandler());
            LoginFormCommand = new Command(()=> LoginFormHandler());
            RegistrationFormCommand = new Command(() => RegistrationFormHandler());
            FurtherCommand = new Command(() => FurtherFormHandler());
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
            }else if (IsRegisterOpen)
            {
                IsForm = false;
                IsAcctepted = false;
                IsFurther = true;
            }
            else
            {
                LoginHandler();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoginHandler()
        {
            string token = await auth.LoginWithEmailPassword(EmailLogin, PasswordLogin);
            App.Current.MainPage.DisplayAlert("Hello, Wysłano email", $"{ token}", "ok");
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
    }

}
