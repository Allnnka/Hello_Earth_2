using Hello_Earth_2.View.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello_Earth_2
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
           
        }
        async void OnNaviageButtonClicked(object sender, EventArgs e)
        {
            var registration = new RegistrationParentPage();
            await Navigation.PushAsync(registration);
        }
    }
}
