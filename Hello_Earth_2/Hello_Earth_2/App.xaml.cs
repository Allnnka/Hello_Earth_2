﻿using Hello_Earth_2.View.Home;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_Earth_2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new HomePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
