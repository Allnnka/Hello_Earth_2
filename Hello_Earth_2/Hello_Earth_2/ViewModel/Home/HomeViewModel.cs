using Hello_Earth_2.Model.UserAuth;
using Hello_Earth_2.Services;
using Hello_Earth_2.View.ConfigurationParent;
using Hello_Earth_2.View.Home.RegistrationChild;
using Hello_Earth_2.View.Home.RegistrationParent;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        
        private bool _isRegistrationParent = false;
        private bool _isRegistrationChild = false;
        private bool _isLogin = true;
        private bool _isRegister = false;
        private string _emailLogin;
        private string _passwordLogin;
       

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
        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
      
       
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
        private async void FurtherFormHandler()
        {
            if (IsRegister && IsRegistrationParent)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new RegistrationParentPage());
            } 
            else if (IsRegister && IsRegistrationChild) 
            { 
                await Application.Current.MainPage.Navigation.PushAsync(new RegistrationChildPage());
            }
            else
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
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
