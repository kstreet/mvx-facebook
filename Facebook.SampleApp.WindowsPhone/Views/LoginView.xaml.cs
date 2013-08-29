using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BeingTheWorst.MvxPlugins.AzureMobileAuthN.ViewModels;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Facebook.SampleApp.WindowsPhone.Views
{
    public partial class LoginView : MvxPhonePage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Use this code behind hack to take the AuthN data and put it somwhere
            // this running App can get access to for testing.
            Debug.WriteLine("In the Facebook LoginView: {0}, {1}", this.UserId.Text, this.AzureToken.Text);

            GlobalVariablesForTesting.CurrentUserId = this.UserId.Text;
            GlobalVariablesForTesting.CurrentUserId = this.AzureToken.Text;

            // Navigate to a new Facebook Test Views from here.  See Nav hack below
            var nav = new NavigateMyselfService();
            nav.GoWild();

        }
    }

    public interface INavigateMyselfService
    {
        void GoWild();
    }

    public class NavigateMyselfService
       : MvxNavigatingObject
       , INavigateMyselfService
    {
        public void GoWild()
        {
            ShowViewModel<HomeViewModel>();
        }
    }
}