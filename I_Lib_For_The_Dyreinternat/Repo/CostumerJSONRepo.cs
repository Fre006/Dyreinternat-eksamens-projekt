using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class CostumerJSONRepo : ICostumerJSONRepo
    {
        private IPersonJSONRepo _personRepo;
        public List<Costumer> _costumer = new List<Costumer>();

        public CostumerJSONRepo(IPersonJSONRepo PersonRepo)
        {
            _personRepo = PersonRepo;
            try
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
        }

        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string path = "Costumer.json";
            string json = File.ReadAllText(path);

            _costumer = JsonSerializer.Deserialize<List<Costumer>>(json);
        }

        public virtual void Add(Costumer costumer)
        {
            int newid = _personRepo.GiveID(costumer.Id);
            _costumer.Add(costumer);
            SaveFile();
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {
            string path = "Costumer.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_costumer));
        }

        public List<Costumer> GetAll()
        {
            return _costumer;
        }
        private int GetIndexByID(int ID)
        {
            //returns 0 if chipID isn't found
            int index = 0;
            for (int i = 0; i < _costumer.Count; i++)
            {
                if (_costumer[i].Id == ID)
                {

                    index = i;

                }
            }
            return index;
        }
        public Costumer GetByID(int ID)
        {
            Costumer theCostumer = new Costumer();
            int index = GetIndexByID(ID);

            if (_costumer[index].Id == ID)
            {
                theCostumer = _costumer[index];
            }
            return theCostumer;

        }
    }
}
