using System;
using System.Collections.Generic;
using System.Windows;

namespace GestureControl
{
    [Serializable]
    public class CommandMappings
    {
        public CommandType CommandType { get; set; }
        public string CommandParam { get; set; }
        public string Gesture { get; set; }
    }

    public enum CommandType
    {
        Shortcut,
        Process
    }

    /// <summary>
    /// Interaction logic for CommandMap.xaml
    /// </summary>
    public partial class CommandMap : Window
    {
        public CommandMap()
        {
            InitializeComponent();

            MapGrid.ItemsSource = DataManger.CommandsMaps;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var data = MapGrid.ItemsSource as List<CommandMappings>;
            if(data.IsNotNull() && data.Count>0)
            {
                DataManger.CommandsMaps = data;
                DataManger.Save();
                DataManger.Load();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
