using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.Home
{
    public class HomeViewModel
    {
        private bool _isRegistrationParent = false;
        private bool _isRegistrationChild = false;
        private bool _isLogin = true;

        private Color _loginColor = Color.Red;
        private Color _registrationColor = Color.Gray;

        public ICommand ParentCommand { get; set; }
        public ICommand PlayerCommand { get; set; }
        public ICommand LoginFormCommand { get; set; }
        public ICommand RegistrationFormCommand { get; set; }

        public bool IsRegistrationParent
        { 
            get { return _isRegistrationParent; }
            set { _isRegistrationParent = value; } 
        }
        public bool IsRegistrationChild
        {
            get { return _isRegistrationChild; }
            set { _isRegistrationChild = value; }
        }
        public bool IsLogin
        {
            get { return _isLogin; }
            set { _isLogin = value; }
        }

        public Color LoginColor
        {
            get { return _loginColor; }
            set { _loginColor = value; }
        }

        public Color RegistrationColor
        {
            get { return _registrationColor; }
            set { _registrationColor = value; }
        }


        public HomeViewModel()
        {
            ParentCommand = new Command(()=> RegistrationParentHandler());
            PlayerCommand = new Command(()=> RegistrationChildHandler());
            LoginFormCommand = new Command(()=> LoginFormHandler());
            RegistrationFormCommand = new Command(() => RegistrationFormHandler());
        }

        private void RegistrationParentHandler()
        {
            _isRegistrationParent = !_isRegistrationParent;
        }

        private void RegistrationChildHandler()
        {
            _isRegistrationChild =!_isRegistrationChild;
        }

        private void LoginFormHandler()
        {
            _isLogin = true;
            _loginColor = Color.Red;
            _registrationColor = Color.Gray;
        }

        private void RegistrationFormHandler()
        {
            _isLogin = false;
            _loginColor = Color.Gray;
            _registrationColor = Color.Red;
        }
    }

}
