/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AMIClaimReporter.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using AMIClaimReporter.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<YourPhotosViewModel>();
            SimpleIoc.Default.Register<YourClaimsViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<ScanViewModel>();
            SimpleIoc.Default.Register<YourDetailsViewModel>();
            SimpleIoc.Default.Register<YourLocationViewModel>();
            SimpleIoc.Default.Register<YourVehicleViewModel>();
            SimpleIoc.Default.Register<SubmitClaimViewModel>();

            SimpleIoc.Default.Register<MainModel>();
        }


        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public YourClaimsViewModel YourClaimsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<YourClaimsViewModel>();
            }
        } 

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public YourVehicleViewModel YourVehicleViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<YourVehicleViewModel>();
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public YourLocationViewModel YourLocationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<YourLocationViewModel>();
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public YourDetailsViewModel YourDetailsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<YourDetailsViewModel>();
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public ScanViewModel ScanViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ScanViewModel>();
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public RegisterViewModel RegisterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public HomeViewModel HomeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }


        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public YourPhotosViewModel YourPhotosViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<YourPhotosViewModel>();
            }
        }
        
        /// <summary>
        /// Gets the MainModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainModel MainModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainModel>();
            }
        }


        /// <summary>
        /// Gets the MainModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public SubmitClaimViewModel SubmitClaimViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SubmitClaimViewModel>();
            }
        }
    }
}