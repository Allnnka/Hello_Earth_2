using Hello_Earth_2.Services;
using Hello_Earth_2.ViewModel.Home.RegistrationChild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2.View.Home.RegistrationChild
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationChildPage : ContentPage
    {
        public RegistrationChildPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationChildViewModel();
        }
        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScannerServices>();
                var result = await scanner.GetScan();
                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void CameraScanner_OnScanResult(ZXing.Result result)
        {
            ((RegistrationChildViewModel)BindingContext).OnScanComplete(result.Text);
        }
    }
}