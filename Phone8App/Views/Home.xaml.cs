using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AMIClaimReporter.Model;
using System.IO.IsolatedStorage;
using AMIClaimReporter.ViewModel;
using System.Collections.ObjectModel;

namespace AMIClaimReporter
{
    public partial class Home : PhoneApplicationPage
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        public Home()
        {
            InitializeComponent();

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            
            //settings.Clear();

            if (settings.Contains("CustomerNo"))
            {
                _mainModel.CustomerNo = settings["CustomerNo"].ToString();
                _mainModel.InsuredName = settings["InsuredName"].ToString();
                _mainModel.InsuredDob = settings["InsuredDob"].ToString();

                _mainModel.InsuredPhoneHome = settings["InsuredPhoneHome"].ToString();
                _mainModel.InsuredPhoneBusiness = settings["InsuredPhoneBusiness"].ToString();
                _mainModel.InsuredAddress = settings["InsuredAddress"].ToString();
                _mainModel.InsuredEmail = settings["InsuredEmail"].ToString();

                _mainModel.Policies = (ObservableCollection<Policy>)settings["Policies"];

            }

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (_mainModel.CustomerNo == null)
            {
                NavigationService.Navigate(new Uri("/Views/Register.xaml", UriKind.Relative));
            }
        }

        private void btnPersonalDetails_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/YourDetails.xaml", UriKind.Relative));
        }

        private void btnClaims_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/YourClaims.xaml", UriKind.Relative));
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Clear();

            NavigationService.Navigate(new Uri("/Views/Register.xaml", UriKind.Relative));
        }


    }
}