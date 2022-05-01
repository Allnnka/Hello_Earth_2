using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(Hello_Earth_2.Services.ServiceImplementation.QrScannerServiceImplementation))]
namespace Hello_Earth_2.Services.ServiceImplementation
{
    public class QrScannerServiceImplementation : IQrScannerServices
    {
        public async Task<string> GetScan()
        {
            var optionsCustom = new MobileBarcodeScanningOptions();
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Zeskanuj kod QR rodzica",
                BottomText = "Prosze czekać"
            };
            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}
