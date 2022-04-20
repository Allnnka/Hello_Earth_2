using Hello_Earth_2.ViewModel.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2.View.ConfigurationParent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurationParentPage : ContentPage
    {
        public ConfigurationParentPage()
        {
            InitializeComponent();
            BindingContext = new ConfigurationParentViewModel();
        }
    }
}