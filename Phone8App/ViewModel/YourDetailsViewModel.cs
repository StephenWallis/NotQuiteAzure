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
    public class YourDetailsViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        #region Commands

        public RelayCommand DoneCommand { get; private set; }

        #endregion

        #region Properties

        public string CustomerNo
        {
            get
            {
                return _mainModel.CustomerNo;
            }

            set
            {
                if (value != _mainModel.CustomerNo)
                {
                    _mainModel.CustomerNo = value;
                    RaisePropertyChanged("CustomerNo");
                }
            }
        }

        public string InsuredName
        {
            get
            {
                return _mainModel.InsuredName;
            }

            set
            {
                if (value != _mainModel.InsuredName)
                {
                    _mainModel.InsuredName = value;
                    RaisePropertyChanged("InsuredName");
                }
            }
        }

        public string InsuredAddress
        {
            get
            {
                return _mainModel.InsuredAddress;
            }

            set
            {
                if (value != _mainModel.InsuredAddress)
                {
                    _mainModel.InsuredAddress = value;
                    RaisePropertyChanged("InsuredAddress");
                }
            }
        }

        public string InsuredPhoneHome
        {
            get
            {
                return _mainModel.InsuredPhoneHome;
            }

            set
            {
                if (value != _mainModel.InsuredPhoneHome)
                {
                    _mainModel.InsuredPhoneHome = value;
                    RaisePropertyChanged("InsuredPhoneHome");

                }
            }
        }

        public string InsuredPhoneBusiness
        {
            get
            {
                return _mainModel.InsuredPhoneBusiness;
            }

            set
            {
                if (value != _mainModel.InsuredPhoneBusiness)
                {
                    _mainModel.InsuredPhoneBusiness = value;
                    RaisePropertyChanged("InsuredPhoneBusiness");

                }
            }
        }

        public string InsuredEmail
        {
            get
            {
                return _mainModel.InsuredEmail;
            }

            set
            {
                if (value != _mainModel.InsuredEmail) 
                {
                    _mainModel.InsuredEmail = value;
                    RaisePropertyChanged("EmailAddress");
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the YourDetailsViewModel class.
        /// </summary>
        public YourDetailsViewModel()
        {
            DoneCommand = new RelayCommand(() => Done());
        }

        #region Command Object Handlers

        private void Done()
        {
            //TODO Remove this?
            //_mainModel.SelectedClaim.YourDetailsComplete = true;
        }

        #endregion
    }
}