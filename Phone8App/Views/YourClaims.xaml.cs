using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AMIClaimReporter
{
    public partial class YourClaims : PhoneApplicationPage
    {
        public YourClaims()
        {
            InitializeComponent();
        }

        private void btnCreateNewClaim_Click(object sender, RoutedEventArgs e)
        {
            NotQuiteAzureClient client = new NotQuiteAzureClient();
            //client.
            //// Use the 'client' variable to call operations on the service.
            //client.

            // Always close the client.
            //client.Close();


            NavigationService.Navigate(new Uri("/Views/NewClaim.xaml", UriKind.Relative));
        }

    }
}