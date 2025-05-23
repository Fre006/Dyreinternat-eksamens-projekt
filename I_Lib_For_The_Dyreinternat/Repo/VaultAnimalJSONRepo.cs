using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class VaultAnimalJSONRepo: IVaultAnimalJSONRepo
    {
        public Dictionary<string, Animal> _AnimalVault = new Dictionary<string, Animal>();
        public VaultAnimalJSONRepo()
        {
            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
        }
        private void LoadFile()
        {
            string path = "AnimalVault.json";
            string json = File.ReadAllText(path);

            _AnimalVault = JsonSerializer.Deserialize<Dictionary<string, Animal>>(json);
        }
        private void SaveFile()
        {
            string path = "AnimalVault.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_AnimalVault));
        }
        public void VaultAnimal(Animal oldAnimal)
        {
            _AnimalVault.Add(oldAnimal.ChipID, oldAnimal);
            SaveFile();
        }
        public Animal VaultGetAnimal(string Key)
        {
            if (_AnimalVault.ContainsKey(Key))
            {
                return _AnimalVault[Key];
            }
            else return null;
        }
    }
}
