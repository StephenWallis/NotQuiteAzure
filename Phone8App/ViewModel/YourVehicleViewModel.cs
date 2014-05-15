using AMIClaimReporter.Entities;
using AMIClaimReporter.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class YourVehicleViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        #region Commands

        public RelayCommand DoneCommand { get; private set; }

        #endregion

        #region Properties

        public ObservableCollection<Policy> Policies
        {
            get
            {
                return _mainModel.Policies;
            }

            set
            {
                if (value != _mainModel.Policies)
                {
                    _mainModel.Policies = value;
                    RaisePropertyChanged("Policies");
                }
            }
        }

        private Policy selectedPolicy;
        public Policy SelectedPolicy
        {
            get
            {
                return selectedPolicy;
            }

            set
            {
                if (value != selectedPolicy)
                {
                    selectedPolicy = value;
                    RaisePropertyChanged("SelectedPolicy");
                }
            }
        }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the YourVehicleViewModel class.
        /// </summary>
        public YourVehicleViewModel()
        {
            DoneCommand = new RelayCommand(() => Done());

            //Policies = new ObservableCollection<Policy>();
        }

        #endregion

        #region Command Object Handlers

        private void Done()
        {

            if (selectedPolicy!=null)
            {
                _mainModel.SelectedClaim.VehicleRegistration = selectedPolicy.VehicleRegistration;
                _mainModel.SelectedClaim.VehicleMake = selectedPolicy.VehicleMake;
                _mainModel.SelectedClaim.VehicleModel = selectedPolicy.VehicleModel;
                _mainModel.SelectedClaim.VehicleYear = selectedPolicy.VehicleYear;
              
            }
        }

        #endregion
    }
}