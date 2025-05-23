using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class VaultEventJSONRepo : IVaultEventJSONRepo
    {
        private IVaultEventJSONRepo _vaultEventRepo;
        public Dictionary<int ,Event> _EventVault = new Dictionary<int, Event>();
        public VaultEventJSONRepo(IVaultEventJSONRepo EventVault)
        {
            _vaultEventRepo = EventVault;
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
            string path = "EventVault.json";
            string json = File.ReadAllText(path);

            _EventVault = JsonSerializer.Deserialize<Dictionary<int, Event>>(json);
        }
        private void SaveFile()
        {
            string path = "EventVault.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_EventVault));
        }
        public void VaultEvent(Event EventVault)
        {
            _EventVault.Add(EventVault.ID, EventVault);
            SaveFile();
        }
        public Event VaultGetEvent(int Key)
        {
            if (_EventVault.ContainsKey(Key))
            {
                return _EventVault[Key];
            }
            else return null;
        }
    }
}
