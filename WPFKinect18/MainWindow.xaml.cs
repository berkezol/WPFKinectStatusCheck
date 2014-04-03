using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;


namespace WPFKinect18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensorChooser sensorChooser;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += sensorChooser_KinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();
        }

        //comment for testing

        void sensorChooser_KinectChanged(object sender, KinectChangedEventArgs e)
        {
            if (e.OldSensor == null)
                return;
            switch (Convert.ToString(e.OldSensor.Status)) 
            {
                case "Undefined": KinectStatus.Content = "Undefined"; break;
                case "Disconnected": KinectStatus.Content = "Disconnected"; break;
                case "Connected" : KinectStatus.Content = "Connected"; break;
                case "Initializing": KinectStatus.Content = "Initializing"; break;
                case "Error": KinectStatus.Content = "Error"; break;
                case "NotPowered": KinectStatus.Content = "NotPowered"; break;
                case "NotReady": KinectStatus.Content = "NotReady"; break;
                case "DeviceNotGenuine": KinectStatus.Content = "DeviceNotGenuine"; break;
                case "DeviceNotSupported": KinectStatus.Content = "DeviceNotSupported"; break;
                case "InsufficientBandwidth": KinectStatus.Content = "InsufficientBandwidth"; break;
                default: KinectStatus.Content = "Undefined"; break;
            }
            //throw new NotImplementedException();
        }
    }
}
