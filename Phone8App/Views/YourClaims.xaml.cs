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

            // slsvcutil.exe http://claimsreporterdev.azurewebsites.net/NotQuiteAzure.svc?wsdl
            // cd C:\Program Files (x86)\Microsoft SDKs\Windows Phone\v8.0\Tools

            //NotQuiteAzureClient client = new NotQuiteAzureClient();
            //client.
            //// Use the 'client' variable to call operations on the service.
            //client.

            // Always close the client.
            //client.Close();


            NavigationService.Navigate(new Uri("/Views/NewClaim.xaml", UriKind.Relative));
        }

    }
}