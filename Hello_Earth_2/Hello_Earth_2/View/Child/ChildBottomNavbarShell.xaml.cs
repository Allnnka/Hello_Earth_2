using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2.View.Child
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildBottomNavbarShell : Shell
    {
        public ChildBottomNavbarShell()
        {
            InitializeComponent();
        }
    }
}