using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AMIClaimReporter.ViewModel;

namespace AMIClaimReporter
{
    public partial class SubmitClaim : PhoneApplicationPage
    {
        public SubmitClaim()
        {
            InitializeComponent();
        }


        private void iconPrev_Click(object sender, EventArgs e)
        {
            var _viewModel = (new ViewModelLocator()).YourLocationViewModel;
            _viewModel.DoneCommand.Execute(null);

            NavigationService.Navigate(new Uri("/Views/YourPhotos.xaml", UriKind.Relative));
        }

        private void iconSave_Click(object sender, EventArgs e)
        {
            var _viewModel = (new ViewModelLocator()).YourLocationViewModel;
            _viewModel.DoneCommand.Execute(null);

            NavigationService.Navigate(new Uri("/Views/YourClaims.xaml", UriKind.Relative));
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //var _viewModel = (new ViewModelLocator()).YourLocationViewModel;
            //_viewModel.DoneCommand.Execute(null);

            //NavigationService.Navigate(new Uri("/Views/WhatNext.xaml", UriKind.Relative));
        }

    }
}