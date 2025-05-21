using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal interface IVaultAnimalJSONRepo
    {
        public void VaultAnimal(Animal oldAnimal);
        public Animal VaultGetAnimal(string Key);

    }
}
