using Hello_Earth_2.Services.ServiceImplementation;
using Hello_Earth_2.ViewModel.Child.ChildHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2.View.Child.ChildHome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildHomePage : ContentPage
    {
        public ChildHomePage()
        {
            InitializeComponent();
            BindingContext = new ChildHomeViewModel();
        }
    }
}