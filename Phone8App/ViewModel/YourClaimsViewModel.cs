using AMIClaimReporter.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System;
using System.Collections.Generic;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class YourClaimsViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;
        
        #region Properties

        public List<Claim> Claims
        {
            get
            {
                return _mainModel.Claims;
            }

        }

        #endregion

        #region Commands

        public RelayCommand CreateNewClaimCommand { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public YourClaimsViewModel()
        {
            CreateNewClaimCommand = new RelayCommand(() => CreateNewClaim());
        }

        #endregion

        #region Command Object Handlers

        private void CreateNewClaim()
        {
            Claim newClaim=new Model.Claim();
            newClaim.InsuredName = _mainModel.InsuredName;
            newClaim.InsuredDob = _mainModel.InsuredDob;
            newClaim.ClaimDate = DateTime.Now.ToString("dd/MM/yyyy");
            newClaim.ClaimStatus = "Not Submitted";

            _mainModel.SelectedClaim = newClaim;
            _mainModel.Claims.Add(newClaim);

            // Getting the GeoLocation can take a while, so we kick it off as soon as we know a claim is about to be recorded
            GetLocation();

        }

        #endregion

        private async void GetLocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5), timeout: TimeSpan.FromSeconds(10));
                _mainModel.CurrentLocation = geoposition.Coordinate.ToGeoCoordinate();

            }
            catch (Exception ex)
            {
                //TODO Add error handling for geo location
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    //string message = "location  is disabled in phone settings.";
                }
                //else
                {
                    // something else happened acquiring the location
                }
            }
        }


    }
}