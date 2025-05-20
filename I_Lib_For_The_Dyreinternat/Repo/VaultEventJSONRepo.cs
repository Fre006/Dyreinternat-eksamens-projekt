using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class VaultEventJSONRepo
    {
        public Dictionary<int ,Event> _oldEvents = new Dictionary<int, Event>();

        public void Add(Event oldEvent)
        {
            _oldEvents.Add(oldEvent);
        }
        private void LoadFile()
        {
            string path = "oldEvents.json";
            string json = File.ReadAllText(path);

            _oldEvents = JsonSerializer.Deserialize<Dictionary<int, Event>>(json);
        }
        private void SaveFile()
        {
            string path = "oldEvents.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_oldEvents));
        }
    }
}
