using Hello_Earth_2.View.Registration;
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
        private bool _isRegistrationParent = false;
        private bool _isRegistrationChild = false;
        private bool _isLogin = true;
        private bool _isRegister = false;

        private Color _loginColor = Color.Red;
        private Color _registrationColor = Color.Gray;
        private Color _playerButtonColor = Color.Red;
        private Color _parentButtonColor = Color.Gray;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ParentCommand { get; set; }
        public ICommand PlayerCommand { get; set; }
        public ICommand LoginFormCommand { get; set; }
        public ICommand RegistrationFormCommand { get; set; }
        public ICommand FurtherCommand { get; set; }

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
            ParentButtonColor = Color.Red;
            PlayerButtonColor = Color.Gray;
        }

        private void RegistrationChildHandler()
        {
            IsRegistrationChild =!IsRegistrationChild;
            PlayerButtonColor = Color.Red;
            ParentButtonColor = Color.Gray;
        }

        private void LoginFormHandler()
        {
            IsLogin = true;
            IsRegister = false;
            LoginColor = Color.Red;
            RegistrationColor = Color.Gray;
        }

        private void RegistrationFormHandler()
        {
            IsLogin = false;
            IsRegister = true;
            LoginColor = Color.Gray;
            RegistrationColor= Color.Red;
        }

        private async void FurtherFormHandler()
        {
            if(IsRegister && IsRegistrationParent)
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new RegistrationParentFormPage());
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
