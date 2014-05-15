using AMIClaimReporter.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ClaimViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        private const int SECTION_COMPLETE = 0;
        private const int SECTION_INCOMPLETE = 100;

        #region Properties

        private int yourDetailsOpacity = SECTION_INCOMPLETE;
        public int YourDetailsOpacity
        {
            get
            {
                return (_mainModel.SelectedClaim.YourDetailsComplete ? SECTION_COMPLETE : SECTION_INCOMPLETE);
            }

            set
            {
                if (value != yourDetailsOpacity)
                {
                    yourDetailsOpacity = value;
                    _mainModel.SelectedClaim.YourDetailsComplete = (yourDetailsOpacity == SECTION_COMPLETE);
                    RaisePropertyChanged("YourDetailsOpacity");
                }
            }
        }

        private int yourLocationOpacity = SECTION_INCOMPLETE;
        public int YourLocationOpacity
        {
            get
            {
                return (_mainModel.SelectedClaim.YourLocationComplete? SECTION_COMPLETE : SECTION_INCOMPLETE);
            }

            set
            {
                if (value != yourLocationOpacity)
                {
                    yourLocationOpacity = value;
                    _mainModel.SelectedClaim.YourLocationComplete = (yourLocationOpacity == SECTION_COMPLETE);
                    RaisePropertyChanged("YourLocationOpacity");
                }
            }
        }

        private int yourVehicleOpacity = SECTION_INCOMPLETE;
        public int YourVehicleOpacity
        {
            get
            {
                return (_mainModel.SelectedClaim.YourVehicleComplete ? SECTION_COMPLETE : SECTION_INCOMPLETE);
            }

            set
            {
                if (value != yourVehicleOpacity)
                {
                    yourVehicleOpacity = value;
                    _mainModel.SelectedClaim.YourVehicleComplete = (yourVehicleOpacity == SECTION_COMPLETE);
                    RaisePropertyChanged("YourVehicleOpacity");
                }
            }
        }


        #endregion

        //#region Commands

        //public RelayCommand YourVehicleDoneCommand { get; private set; }
        //public RelayCommand YourLocationDoneCommand { get; private set; }

        //#endregion

        /// <summary>
        /// Initializes a new instance of the ClaimViewModel class.
        /// </summary>

        public ClaimViewModel()
        {
            //YourVehicleDoneCommand = new RelayCommand(() => YourVehicleDone());
            //YourLocationDoneCommand = new RelayCommand(() => YourLocationDone());
        }

        //private void YourVehicleDone()
        //{
        //    _mainModel.SelectedClaim.YourVehicleComplete = true;
        //}

        //private void YourLocationDone()
        //{
        //    YourLocationComplete = SECTION_COMPLETE;
        //}
    }
}