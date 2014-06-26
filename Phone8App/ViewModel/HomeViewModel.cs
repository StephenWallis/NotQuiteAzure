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
        string _callMeText = "Yes, please call me....";

        #region Commands

        public RelayCommand CreateNewClaimCommand { get; private set; }
        public RelayCommand CallMeCommand { get; private set; }

        #endregion

        #region Properties

        public string CallMeText
        {
            get
            {
                return _callMeText;
            }

            set
            {
                if (value != _callMeText)
                {
                    _callMeText = value;
                    RaisePropertyChanged("CallMeText");
                }
            }
        }


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
            client.CallMeCompleted += client_CallMeCompleted;
            client.CallMeAsync(_mainModel.CustomerNo, "021 1759 635");
        }

        void client_CallMeCompleted(object sender, CallMeCompletedEventArgs e)
        {
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                CallMeText = "We will call you soon";
                RaisePropertyChanged("CallMeText");
            });
        }
        #endregion

    }
}