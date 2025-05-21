using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Repo;
using Lib.Model;

namespace Lib.Services
{
    internal class VaultAnimalService
    {
        private IVaultAnimalJSONRepo _VaultAnimalRepo;
        public VaultAnimalService(IVaultAnimalJSONRepo VaultAnimalRepo)
        {
            _VaultAnimalRepo = VaultAnimalRepo;
        }
        public void VaultAnimal(Animal oldAnimal)
        {
            _VaultAnimalRepo.VaultAnimal(oldAnimal);
        }
        public Animal VaultGetAnimal(string Key)
        {
            return _VaultAnimalRepo.VaultGetAnimal(Key);
        }
    }
}
