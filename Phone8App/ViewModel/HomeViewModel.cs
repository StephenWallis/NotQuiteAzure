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
    public class HomeViewModel : ViewModelBase
    {
        MainModel _mainModel = (new ViewModelLocator()).MainModel;

        #region Commands

        public RelayCommand CreateNewClaimCommand { get; private set; }
        public RelayCommand CallMeCommand { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HomeViewModel()
        {
            CreateNewClaimCommand = new RelayCommand(() => CreateNewClaim());
            CallMeCommand = new RelayCommand(() => CallMe());
        }

        #endregion

        #region Command Object Handlers

        private void CreateNewClaim()
        {
            Claim newClaim=new Model.Claim();

            _mainModel.SelectedClaim = newClaim;
            _mainModel.Claims.Add(newClaim);

        }

        private void CallMe()
        {
            NotQuiteAzureClient client = new NotQuiteAzureClient();
            //client.RegisterCompleted += client_RegisterCompleted;
            client.CallMeAsync(_mainModel.CustomerNo, "021 1759 635");
        }

        #endregion

    }
}