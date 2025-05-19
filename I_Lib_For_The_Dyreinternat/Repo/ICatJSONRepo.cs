using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface ICatJSONRepo
    {
        public List<Cat> GetAll();
        public void Add(Cat cat, string path="default");
        public Cat GetByID(string id);

        public List<Event> GetLogs(string id);
        public void AddLog(string id, Event newentry, string path = "default");
        public void Sterilise(string id, string path="default");
        public string GetStatusByID(string chipID);
        public void ChangeStatusByID(string chipID, string status, string path = "default");

        public void DeleteByID(string chipID, string path="default");
    }
}
