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
    public partial class WhatToDo : PhoneApplicationPage
    {
        public WhatToDo()
        {
            InitializeComponent();
        }

        private void iconPrev_Click(object sender, EventArgs e)
        {
            var _viewModel = (new ViewModelLocator()).YourLocationViewModel;
            _viewModel.DoneCommand.Execute(null);

            NavigationService.Navigate(new Uri("/Views/NewClaim.xaml", UriKind.Relative));
        }

        private void iconSave_Click(object sender, EventArgs e)
        {
            var _viewModel = (new ViewModelLocator()).YourLocationViewModel;
            _viewModel.DoneCommand.Execute(null);

            NavigationService.Navigate(new Uri("/Views/YourClaims.xaml", UriKind.Relative));
        }

        private void iconNext_Click(object sender, EventArgs e)
        {
            var _viewModel = (new ViewModelLocator()).YourLocationViewModel;
            _viewModel.DoneCommand.Execute(null);

            NavigationService.Navigate(new Uri("/Views/YourLocation.xaml", UriKind.Relative));
        }
    }
}