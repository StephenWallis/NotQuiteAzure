using AMIClaimReporter.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.IO.IsolatedStorage;
using System.Windows.Navigation;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RegisterViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        #region Commands

        public RelayCommand RegisterCommand { get; private set; }

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

        public string InsuredDob
        {
            get
            {
                return _mainModel.InsuredDob;
            }

            set
            {
                if (value != _mainModel.InsuredDob)
                {
                    _mainModel.InsuredDob = value;
                    RaisePropertyChanged("InsuredDob");
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the RegisterViewModel class.
        /// </summary>
        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(() => Register());


        }

        #endregion

        #region Command Object Handlers

        void client_RegisterCompleted(object sender, RegisterCompletedEventArgs e)
        {
            NotQuiteAzure.Customer result = e.Result;

            _mainModel.InsuredPhoneHome = result.homePhone;
            _mainModel.InsuredPhoneBusiness = result.workPhone;
            _mainModel.InsuredAddress = result.address;
            _mainModel.InsuredEmail = result.email;

            _mainModel.SelectedPolicy = null;
            foreach (NotQuiteAzure.Policy policy in result.Policies)
            {
                _mainModel.Policies.Add(new Policy { PolicyNo = policy.id, VehicleMake = policy.make, VehicleModel = policy.model, VehicleYear = "2000", VehicleRegistration = policy.registration });
            }

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Clear();

            settings.Add("CustomerNo", _mainModel.CustomerNo);
            settings.Add("InsuredName", _mainModel.InsuredName);
            settings.Add("InsuredDob", _mainModel.InsuredDob);

            settings.Add("InsuredPhoneHome", _mainModel.InsuredPhoneHome);
            settings.Add("InsuredPhoneBusiness", _mainModel.InsuredPhoneBusiness);
            settings.Add("InsuredAddress", _mainModel.InsuredAddress);
            settings.Add("InsuredEmail", _mainModel.InsuredEmail);

            settings.Add("Policies", _mainModel.Policies);

            settings.Save();

            Claim newClaim = new Model.Claim();

            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri("/Views/Home.xaml", UriKind.Relative));
        }

        private void Register()
        {
            NotQuiteAzureClient client = new NotQuiteAzureClient();
            client.RegisterCompleted += client_RegisterCompleted;
            client.RegisterAsync(_mainModel.CustomerNo);

        }


        #endregion

    }
}