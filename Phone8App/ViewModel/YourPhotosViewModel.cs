using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using AMIClaimReporter.Entities;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System;
using System.Windows;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;
using AMIClaimReporter.Model;
using System.Collections.Generic;
using AMIClaimReporter.Helpers;
using System.Linq;
using Microsoft.Phone.Controls;
using Windows.Phone.Media.Capture;

namespace AMIClaimReporter.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class YourPhotosViewModel : ViewModelBase
    {
        private int savedCounter = 0;
        PhotoCamera _camera;
        MediaLibrary library = new MediaLibrary();
        private List<PictureInfo> pictures;

        private const int TAB_CAPTURE = 0;
        private const int TAB_VIEW = 1;

        private string _thumbnailPath;
        private string _fullImagePath;


        #region Commands

        public RelayCommand TakePictureCommand { get; private set; }

        public RelayCommand SelectMyVehicleCommand { get; private set; }
        public RelayCommand SelectOtherVehiclesCommand { get; private set; }
        public RelayCommand SelectAccidentSceneCommand { get; private set; }
        public RelayCommand SelectOtherCommand { get; private set; }

        #endregion

        #region Properties

        private Boolean capturePanelVisible;
        public Boolean CapturePanelVisible
        {
            get
            {
                return capturePanelVisible;
            }

            set
            {
                if (value != capturePanelVisible)
                {
                    capturePanelVisible = value;
                    RaisePropertyChanged("CapturePanelVisible");
                }
            }
        }

        private Boolean classifyPanelVisible;
        public Boolean ClassifyPanelVisible
        {
            get
            {
                return classifyPanelVisible;
            }

            set
            {
                if (value != classifyPanelVisible)
                {
                    classifyPanelVisible = value;
                    RaisePropertyChanged("ClassifyPanelVisible");
                }
            }
        }

        private int selectedTab;
        public int SelectedTab
        {
            get
            {
                return selectedTab;
            }

            set
            {
                if (value != selectedTab)
                {
                    selectedTab = value;
                    RaisePropertyChanged("SelectedTab");
                }
            }
        }

        private VideoBrush videoBrushSource;
        public VideoBrush VideoBrushSource
        {
            get
            {
                return videoBrushSource;
            }

            set
            {
                if (value != videoBrushSource)
                {
                    videoBrushSource = value;
                    RaisePropertyChanged("VideoBrushSource");
                }
            }
        }

        private PictureInfo currentPicture;
        public PictureInfo CurrentPicture
        {
            get
            {
                return currentPicture;
            }

            set
            {
                if (value != currentPicture)
                {
                    currentPicture = value;
                    RaisePropertyChanged("CurrentPicture");
                }
            }
        }

        public List<KeyedList<string, PictureInfo>> GroupSource
        {
            get
            {
                var groupedPhotos =
                    from picture in pictures
                    orderby picture.PictureGroup
                    group picture by picture.PictureGroup into photosByMonth
                    select new KeyedList<string, PictureInfo>(photosByMonth);

                return new List<KeyedList<string, PictureInfo>>(groupedPhotos);
            }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the YourDetailsViewModel class.
        /// </summary>
        public YourPhotosViewModel()
        {
            TakePictureCommand = new RelayCommand(() => TakePicture());

            SelectMyVehicleCommand = new RelayCommand(() => SelectMyVehicle());
            SelectOtherVehiclesCommand = new RelayCommand(() => SelectOtherVehicles());
            SelectAccidentSceneCommand = new RelayCommand(() => SelectAccidentScene());
            SelectOtherCommand = new RelayCommand(() => SelectOther());

            pictures = new List<PictureInfo>();
            InitializeCamera();

            SelectedTab = TAB_CAPTURE;
            //SelectedPictureGroup = "";
            CapturePanelVisible = true;
            ClassifyPanelVisible = false;


            CompositeTransform cameraTransform = new CompositeTransform();

            cameraTransform.CenterX = 0.5; // _camera.Resolution.Width / 2;
            cameraTransform.CenterY = 0.5; // _camera.Resolution.Height / 2;
            cameraTransform.Rotation = 90;
            VideoBrushSource.RelativeTransform = cameraTransform;

        }

        #endregion

        #region CommandHandlers

        private void TakePicture()
        {
            if (_camera != null)
            {
                try
                {
                    // Start image capture.
                     _camera.CaptureImage();
                    ClassifyPanelVisible = true;
                    CapturePanelVisible = false;

                    CurrentPicture = new PictureInfo();
                    //CurrentPicture = new PictureInfo() { FullImagePath = new Uri("", UriKind.Absolute), ThumbnailPath = new Uri("", UriKind.Absolute) };
                }
                catch (Exception)
                {
                    // Cannot capture an image until the previous capture has completed.
                }
            }
        }


        private void SelectMyVehicle()
        {
            StorePicture("My Vehicle");
        }

        private void SelectOtherVehicles()
        {
            StorePicture("Other Vehicles");
        }

        private void SelectAccidentScene()
        {
            StorePicture("Accident Scene");
        }

        private void SelectOther()
        {
            StorePicture("Other");
        }

        private void StorePicture(string pictureGroup)
        {
            ClassifyPanelVisible = false;
            CapturePanelVisible = true;

            CurrentPicture.PictureGroup = pictureGroup;

            pictures.Add(CurrentPicture);
            RaisePropertyChanged("GroupSource");
        }

        #endregion

        private void InitializeCamera()
        {

            // Check to see if the camera is available on the device.
            if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true)
            {
                // Otherwise, use standard camera on back of device.
                _camera = new Microsoft.Devices.PhotoCamera(CameraType.Primary);


                // .SetProperty(KnownCameraPhotoProperties

                // Event is fired when the PhotoCamera object has been initialized.
                _camera.Initialized += new EventHandler<Microsoft.Devices.CameraOperationCompletedEventArgs>(cam_Initialized);

                // Event is fired when the capture sequence is complete.
                _camera.CaptureCompleted += new EventHandler<CameraOperationCompletedEventArgs>(cam_CaptureCompleted);

                // Event is fired when the capture sequence is complete and an image is available.
                _camera.CaptureImageAvailable += new EventHandler<Microsoft.Devices.ContentReadyEventArgs>(cam_CaptureImageAvailable);

                // Event is fired when the capture sequence is complete and a thumbnail image is available.
                _camera.CaptureThumbnailAvailable += new EventHandler<ContentReadyEventArgs>(cam_CaptureThumbnailAvailable);

                // The event is fired when the shutter button receives a full press.
                CameraButtons.ShutterKeyPressed += OnButtonFullPress;

                // The event is fired when the shutter button is released.
                CameraButtons.ShutterKeyReleased += OnButtonRelease;

                //Set the VideoBrush source to the camera.
                VideoBrushSource = new VideoBrush();
                VideoBrushSource.SetSource(_camera);
            }
        }

        // Update the UI if initialization succeeds.
        void cam_Initialized(object sender, Microsoft.Devices.CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                // Whatever...
            }
        }

        void cam_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            // Increments the savedCounter variable used for generating JPEG file names.
            savedCounter++;
        }

        // Informs when full resolution picture has been taken, saves to local media library and isolated storage.
        void cam_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
        {
            string fileName = savedCounter + ".jpg";
            
            try
            {
                // Save picture to the library camera roll.
                library.SavePictureToCameraRoll(fileName, e.ImageStream);

                // Set the position of the stream back to start
                e.ImageStream.Seek(0, SeekOrigin.Begin);

                // Save picture as JPEG to isolated storage.
                using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream targetStream = isStore.OpenFile(fileName, FileMode.Create, FileAccess.Write))
                    {
                        _fullImagePath = targetStream.Name;
                        CurrentPicture.FullImagePath = new Uri(_fullImagePath, UriKind.Absolute);

                        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            RaisePropertyChanged("CurrentPicture");
                        });

                        // Initialize the buffer for 4KB disk pages.
                        byte[] readBuffer = new byte[4096];
                        int bytesRead = -1;

                        // Copy the image to isolated storage. 
                        while ((bytesRead = e.ImageStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            targetStream.Write(readBuffer, 0, bytesRead);
                        }
                    }
                }

            }
            finally
            {
                // Close image stream
                e.ImageStream.Close();
            }

        }

        // Informs when thumbnail picture has been taken, saves to isolated storage
        // User will select this image in the pictures application to bring up the full-resolution picture. 
        public void cam_CaptureThumbnailAvailable(object sender, ContentReadyEventArgs e)
        {
            string thumbnailName = savedCounter + "_th.jpg";
            
            try
            {
                // Save thumbnail as JPEG to isolated storage.
                using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream targetStream = isStore.OpenFile(thumbnailName, FileMode.Create, FileAccess.Write))
                    {
                        _thumbnailPath = targetStream.Name;
                        CurrentPicture.ThumbnailPath = new Uri(_thumbnailPath, UriKind.Absolute);

                        // Initialize the buffer for 4KB disk pages.
                        byte[] readBuffer = new byte[4096];
                        int bytesRead = -1;

                        // Copy the thumbnail to isolated storage. 
                        while ((bytesRead = e.ImageStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            targetStream.Write(readBuffer, 0, bytesRead);
                        }

                        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            RaisePropertyChanged("ThumbnailPath");
                        });

                    }
                }

            }
            finally
            {
                // Close image stream
                e.ImageStream.Close();
            }
        }


        // Capture the image with a full button press using the hardware shutter button.
        private void OnButtonFullPress(object sender, EventArgs e)
        {
            if (_camera != null)
            {
                _camera.CaptureImage();
            }
        }

        // Cancel the focus if the half button press is released using the hardware shutter button.
        private void OnButtonRelease(object sender, EventArgs e)
        {

            if (_camera != null)
            {
                _camera.CancelFocus();
            }
        }

        public override void Cleanup()
        {
            if (_camera != null)
            {
                // Dispose camera to minimize power consumption and to expedite shutdown.
                _camera.Dispose();

                // Release memory, ensure garbage collection.
                _camera.Initialized -= cam_Initialized;
                _camera.CaptureCompleted -= cam_CaptureCompleted;
                _camera.CaptureImageAvailable -= cam_CaptureImageAvailable;
                _camera.CaptureThumbnailAvailable -= cam_CaptureThumbnailAvailable;
                CameraButtons.ShutterKeyPressed -= OnButtonFullPress;
                CameraButtons.ShutterKeyReleased -= OnButtonRelease;
            }
        }



        //void ChangeOrientation(Boolean isLandscapeRight)
        //{
        //    if (_camera != null)
        //    {
        //        // LandscapeRight rotation when camera is on back of device.
        //        int landscapeRightRotation = 180;

        //        // Change LandscapeRight rotation for front-facing camera.
        //        if (_camera.CameraType == CameraType.FrontFacing) landscapeRightRotation = -180;

        //        // Rotate video brush from camera.
        //        if (isLandscapeRight)
        //        {
        //            // Rotate for LandscapeRight orientation.
        //            videoBrushSource.RelativeTransform =
        //                new CompositeTransform() { CenterX = 0.5, CenterY = 0.5, Rotation = landscapeRightRotation };
        //        }
        //        else
        //        {
        //            // Rotate for standard landscape orientation.
        //            videoBrushSource.RelativeTransform =
        //                new CompositeTransform() { CenterX = 0.5, CenterY = 0.5, Rotation = 0 };
        //        }
        //    }
        //}



    }
}