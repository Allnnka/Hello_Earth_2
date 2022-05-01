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
        private bool _isAnalyzing = false;
        private bool _isScanning = false;
        private bool _isForm = true;
        public ICommand EnableScannerCommand { get; set; }

        public RegistrationChildViewModel()
        {
            EnableScannerCommand = new Command(() => EnableScannerHandler());
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

        public bool IsForm
        {
            get
            {
                return _isForm;
            }
            set
            {
                _isForm = value;
                OnPropertyChanged(nameof(IsForm));
            }
        }

        private void EnableScannerHandler()
        {
            IsForm = false;
            IsScanning = true;
        }
        public void OnScanComplete(string scannedCode)
        {
            Console.WriteLine(scannedCode);
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
