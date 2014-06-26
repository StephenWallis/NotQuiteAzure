using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using AMIClaimReporter.Entities;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System;
using System.Windows;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;
using AMIClaimReporter.Model;
using GalaSoft.MvvmLight.Messaging;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SubmitClaimViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        #region Commands

        public RelayCommand SubmitCommand { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the YourLocationViewModel class.
        /// </summary>
        public SubmitClaimViewModel()
        {
            SubmitCommand = new RelayCommand(() => Submit());
        }

        #region Command Object Handlers

        private void Submit()
        {
            NotQuiteAzureClient client = new NotQuiteAzureClient();
            client.RegisterClaimCompleted += client_SubmitCompleted;
            client.RegisterClaimAsync(_mainModel.CustomerNo, _mainModel.CurrentLocation.Longitude, _mainModel.CurrentLocation.Latitude, "M01");
        }

        void client_SubmitCompleted(object sender, RegisterClaimCompletedEventArgs e)
        {
            _mainModel.Claims[_mainModel.Claims.Count - 1].ClaimNo = e.Result.ToString();
            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri("/Views/WhatNext.xaml", UriKind.Relative));
        }

        #endregion
    }
}