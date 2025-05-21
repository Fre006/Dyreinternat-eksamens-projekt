using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal interface IVaultEventJSONRepo
    {
        public void VaultEvent(Event oldEvent);
        public Event VaultGetEvent(int Key);
    }
}
