using System;
using System.Windows;
using Microsoft.Phone.Controls;
using AMIClaimReporter.Model;
using AMIClaimReporter.ViewModel;
using System.IO.IsolatedStorage;

namespace AMIClaimReporter
{
    public partial class Register : PhoneApplicationPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Home.xaml", UriKind.Relative));
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Scan.xaml", UriKind.Relative));
        }

    }
}