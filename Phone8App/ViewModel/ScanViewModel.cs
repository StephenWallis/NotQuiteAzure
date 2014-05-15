using GalaSoft.MvvmLight;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ScanViewModel : ViewModelBase
    {
        #region Properties

        private string customerNo = "";
        public string CustomerNo
        {
            get
            {
                return customerNo;
            }

            set
            {
                if (value != customerNo)
                {
                    customerNo = value;
                    RaisePropertyChanged("CustomerNo");
                }
            }
        }

        private string insuredName = "";
        public string InsuredName
        {
            get
            {
                return insuredName;
            }

            set
            {
                if (value != insuredName)
                {
                    insuredName = value;
                    RaisePropertyChanged("InsuredName");
                }
            }
        }

        private string insuredDob = "";
        public string InsuredDob
        {
            get
            {
                return insuredDob;
            }

            set
            {
                if (value != insuredDob)
                {
                    insuredDob = value;
                    RaisePropertyChanged("InsuredDob");
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the ScanViewModel class.
        /// </summary>
        public ScanViewModel()
        {
        }
    }
}