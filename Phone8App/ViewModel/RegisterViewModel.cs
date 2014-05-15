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

        private void Register()
        {
            //TODO Remove the debug code
            switch (_mainModel.CustomerNo)
            {
                case "1079607":
                    _mainModel.InsuredPhoneHome = "03 312 8967";
                    _mainModel.InsuredPhoneBusiness = "03 345 8077";
                    _mainModel.InsuredAddress = "9128 Random Street, RD24, Kaiapoi, 1895";
                    _mainModel.InsuredEmail = "bob.jones@hotmail.com";

                    _mainModel.SelectedPolicy = null;
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1099809M01", VehicleMake = "Toyota", VehicleModel = "Corolla", VehicleYear = "2000", VehicleRegistration = "TER453" });
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1099809M02", VehicleMake = "Holden", VehicleModel = "Corsa", VehicleYear = "1998", VehicleRegistration = "EJM900" });
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1099809M03", VehicleMake = "Mazda", VehicleModel = "MX5", VehicleYear = "2010", VehicleRegistration = "MAZ003" });

                    break;

                case "2349981":
                    _mainModel.InsuredPhoneHome = "03 313 4502";
                    _mainModel.InsuredPhoneBusiness = "03 344 7867";
                    _mainModel.InsuredAddress = "Northwood Towers, Ashburton, 7098";
                    _mainModel.InsuredEmail = "steve.hadwin@hotmail.com";

                    _mainModel.SelectedPolicy = null;
                    _mainModel.Policies.Add(new Policy { PolicyNo = "2349981M01", VehicleMake = "Ford", VehicleModel = "Focus", VehicleYear = "2007", VehicleRegistration = "EER784" });
                    _mainModel.Policies.Add(new Policy { PolicyNo = "2349981M02", VehicleMake = "Lotus", VehicleModel = "Elise", VehicleYear = "2012", VehicleRegistration = "HJY458" });

                    break;

                case "1098767":
                    _mainModel.InsuredPhoneHome = "03 312 7810";
                    _mainModel.InsuredPhoneBusiness = "03 365 0098";
                    _mainModel.InsuredAddress = "16 Westbourne Street, Ashburton, 9087";
                    _mainModel.InsuredEmail = "Tanya1203@hotmail.com";

                    _mainModel.SelectedPolicy = null;
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1098767M01", VehicleMake = "Vauxhall", VehicleModel = "Vectre", VehicleYear = "1989", VehicleRegistration = "VEC021" });

                    break;

                default:
                    _mainModel.CustomerNo = "1099809";
                    _mainModel.InsuredName = "Frank Joseph";
                    _mainModel.InsuredDob = "08121967";

                    _mainModel.InsuredPhoneHome = "03 312 8967";
                    _mainModel.InsuredPhoneBusiness = "03 345 8077";
                    _mainModel.InsuredAddress = "90 North Road, RD5, Kaiapoi, 7698";
                    _mainModel.InsuredEmail = "Frank1204@hotmail.com";

                    _mainModel.SelectedPolicy = null;
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1099809M01", VehicleMake = "Toyota", VehicleModel = "Corolla", VehicleYear = "2000", VehicleRegistration = "TER453" });
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1099809M02", VehicleMake = "Holden", VehicleModel = "Corsa", VehicleYear = "1998", VehicleRegistration = "EJM900" });
                    _mainModel.Policies.Add(new Policy { PolicyNo = "1099809M03", VehicleMake = "Mazda", VehicleModel = "MX5", VehicleYear = "2010", VehicleRegistration = "MAZ003" });

                    break;
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

        }

        #endregion

    }
}