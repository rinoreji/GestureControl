using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestureControl
{
    public class DataManger
    {
        public static readonly string GESTURE_CONTROLS_FILE = "GestureControls.xml";

        public static List<CommandMappings> CommandsMaps { get; set; }

        public static void Save()
        {
            if (CommandsMaps.IsNull())
                CommandsMaps = new List<CommandMappings>();

            var serialized = CommandsMaps.SerializeObjectToXML();
            File.WriteAllText(GESTURE_CONTROLS_FILE, serialized);
        }

        public static void Load()
        {
            if (File.Exists(GESTURE_CONTROLS_FILE))
            {
                var serialized = File.ReadAllText(GESTURE_CONTROLS_FILE);
                CommandsMaps = serialized.DeserializeFromXml<List<CommandMappings>>();
            }
            else
                CommandsMaps = new List<CommandMappings>();
        }
    }
}
