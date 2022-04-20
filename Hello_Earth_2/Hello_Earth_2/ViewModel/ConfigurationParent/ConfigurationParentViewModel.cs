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

namespace Hello_Earth_2.ViewModel.Configuration
{
    public class ConfigurationParentViewModel : INotifyPropertyChanged
    {
        FamilyServiceImplementation familyService;
        UserServiceImplementation userService;
        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isCreatingFamily = true;
        private bool _isQrCodeButton = false;
        private bool _isQrCodeShown = false;

        public ICommand CreateFamilyCommand { get; set; }
        public ICommand GenerateQRCodeCommand { get; set; }

        public ConfigurationParentViewModel()
        {
            familyService = new FamilyServiceImplementation();
            userService = new UserServiceImplementation();
            CreateFamilyCommand = new Command(() => CreateFamilyHandler());
            GenerateQRCodeCommand = new Command(() => GenerateQRCodeHandler());
        }
        public bool IsCreatingFamily
        {
            get { return _isCreatingFamily; }
            set { 
                _isCreatingFamily = value; 
                OnPropertyChanged(nameof(IsCreatingFamily));
            }
        }

        public bool IsQrCodeButton
        {
            get { return _isQrCodeButton; }
            set
            {
                _isQrCodeButton = value;
                OnPropertyChanged(nameof(IsQrCodeButton));
            }
        }

        public bool IsQrCodeShown
        {
            get { return _isQrCodeShown; }
            set
            {
                _isQrCodeShown = value;
                OnPropertyChanged(nameof(IsQrCodeShown));
            }
        }

        private async void CreateFamilyHandler()
        {
            UserAuth userAuth = auth.GetUserAuth();
            User user = await userService.GetUser(userAuth.Uid);
            Family family = new Family();
            family.Parent = new Parent();
            family.Parent.UserName = user.UserName;
            family.Parent.Email = user.Email; 
            family.Parent.Role = user.Role;
            await familyService.CreateFamily(family,userAuth.Uid);
            IsCreatingFamily = false;
            IsQrCodeButton = true;
        }

        private void GenerateQRCodeHandler()
        {
            IsQrCodeButton = false;
            IsQrCodeShown = true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
