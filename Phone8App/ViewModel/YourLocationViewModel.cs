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
    public class YourLocationViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        #region Commands

        public RelayCommand DoneCommand { get; private set; }

        #endregion

        #region Properties

        private GeoCoordinate mapCenter;
        public GeoCoordinate MapCenter
        {
            get
            {
                return mapCenter;
            }

            set
            {
                if (value != mapCenter)
                {
                    mapCenter = value;
                    RaisePropertyChanged("MapCenter");
                }
            }
        }

        private int mapZoomLevel;
        public int MapZoomLevel
        {
            get
            {
                return mapZoomLevel;
            }

            set
            {
                if (value != mapZoomLevel)
                {
                    mapZoomLevel = value;
                    RaisePropertyChanged("MapZoomLevel");
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the YourLocationViewModel class.
        /// </summary>
        public YourLocationViewModel()
        {
            if (_mainModel.CurrentLocation!=null)
            {
                MapCenter = _mainModel.CurrentLocation;
                MapZoomLevel = 15;               
            }
            else
            {
                MapCenter = new GeoCoordinate(-41.266484996303916, 173.78600458614528);
                MapZoomLevel = 5;
            }


            DoneCommand = new RelayCommand(() => Done());
        }

        #region Command Object Handlers

        private void Done()
        {
            //TODO Remove this?
            //_mainModel.SelectedClaim.YourLocationComplete = true;
        }

        #endregion
    }
}