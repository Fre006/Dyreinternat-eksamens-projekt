using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class VaultAnimalJSONRepo
    {
        public Dictionary<int, Animal> _oldAnimal = new Dictionary<int, Animal>();
        private void LoadFile()
        {
            string path = "oldAnimal.json";
            string json = File.ReadAllText(path);

            _oldAnimal = JsonSerializer.Deserialize<Dictionary<int, Animal>>(json);
        }
        private void SaveFile()
        {
            string path = "oldEvents.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_oldAnimal));
        }

    }
}
