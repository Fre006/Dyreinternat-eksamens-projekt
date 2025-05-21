using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;

namespace Lib.Services
{
    internal class VaultEventService
    {
        private IVaultEventJSONRepo _VaultEventRepo;
        public VaultEventService(IVaultEventJSONRepo VaultEventRepo)
        {
            _VaultEventRepo = VaultEventRepo;
        }
        public void VaultAnimal(Event oldEvent)
        {
            _VaultEventRepo.VaultEvent(oldEvent);
        }
        public Event VaultGetAnimal(int Key)
        {
            return _VaultEventRepo.VaultGetEvent(Key);
        }
    }
}
