using MouseGestures;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Forms = System.Windows.Forms;

namespace GestureControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MouseGestures.MouseGestures _gestureDectector;
        private Forms.NotifyIcon notifyIcon = null;

        public MainWindow()
        {
            InitializeComponent();
            Subscribe();

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataManger.Load();
            notifyIcon.Visible = true;
        }

        public void Subscribe()
        {
            _gestureDectector = new MouseGestures.MouseGestures(true);

            _gestureDectector.Gesture += _gestureDectector_Gesture;
            _gestureDectector.DirectionAdded += _gestureDectector_DirectionAdded;
        }

        void _gestureDectector_DirectionAdded(object sender, MouseGestureEventArgs e)
        {
            GuestureDirectionList.Items.Clear();
            foreach (var item in e.Gesture.Motions)
            {
                GuestureDirectionList.Items.Add(GetImageFromName(item.ToString()));
            }
        }

        void _gestureDectector_Gesture(object sender, MouseGestureEventArgs e)
        {
            GuestureDirectionList.Items.Clear();

            var command = DataManger.CommandsMaps.FirstOrDefault(c => c.Gesture.ToUpper() == e.Gesture.ToString().ToUpper());
            if (command.IsNotNull())
            {
                ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(CommandMappings command)
        {
            using (var executionManager = new CommandExecutionManager(command))
            {
                executionManager.Execute();
            }
        }

        BitmapImage GetImageFromName(string name)
        {
            var uriString = string.Format("../Images/{0}.png", name);
            return new BitmapImage(new Uri(uriString, UriKind.RelativeOrAbsolute));
        }
    }
}
