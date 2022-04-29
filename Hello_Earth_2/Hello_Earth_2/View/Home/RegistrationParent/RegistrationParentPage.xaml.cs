using Hello_Earth_2.ViewModel.Home.RegistrationParent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2.View.Home.RegistrationParent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationParentPage : ContentPage
    {
        public RegistrationParentPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationParentViewModel();
        }
    }
}