using System;
using System.Windows;
using Forms = System.Windows.Forms;

namespace GestureControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Forms.NotifyIcon notifyIcon = null;
        public App()
        {
            notifyIcon = new Forms.NotifyIcon();
            notifyIcon.Icon = GestureControl.Properties.Resources.appIco;
            PrepareContextMenu();
        }

        void PrepareContextMenu()
        {
            var contextMenu = new Forms.ContextMenu();
            var exitMenu = new Forms.MenuItem();
            exitMenu.Text = "E&xit";
            exitMenu.Click += exitMenu_Click;

            var commandMap = new Forms.MenuItem();
            commandMap.Text = "Configure";
            commandMap.Click += commandMap_Click;

            contextMenu.MenuItems.AddRange(new Forms.MenuItem[] { commandMap, exitMenu });
            notifyIcon.ContextMenu = contextMenu;
        }

        void commandMap_Click(object sender, EventArgs e)
        {
            CommandMap mapWindow = new CommandMap();
            mapWindow.ShowDialog();
        }

        void exitMenu_Click(object sender, System.EventArgs e)
        {
            DisposeNotifyIcon();
            App.Current.Shutdown();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            notifyIcon.Visible = true;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DisposeNotifyIcon();
            base.OnExit(e);
        }

        void DisposeNotifyIcon()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }
}
