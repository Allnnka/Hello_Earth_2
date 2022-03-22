using Hello_Earth_2.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2.View.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationParentFormPage : ContentPage
    {
        public RegistrationParentFormPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationParentViewModel();
        }
    }
}