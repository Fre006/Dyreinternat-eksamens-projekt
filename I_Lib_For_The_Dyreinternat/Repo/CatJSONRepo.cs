using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    internal class CatJsonRepo
    {
        private string _path="Cat.json";
        protected List<Cat> _cats = new List<Cat>();

        public void CatJSONRepo()
        {
            LoadFile();
        }

        public List<Cat> GetAll()
        {
            return _cats;
        }

        public void Add(Cat cat)
        {
            _cats.Add(cat);
            SaveFile();
        }


        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string json = File.ReadAllText(_path);

            _cats = JsonSerializer.Deserialize<List<Cat>>(json);
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {

            File.WriteAllText(_path, JsonSerializer.Serialize(_cats));
        }
    }
}
