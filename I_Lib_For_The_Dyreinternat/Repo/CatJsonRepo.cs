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
        string Path="Cat.json";
        protected List<Cat> _cats = new List<Cat>();

        public void CatJSONRepository(string path=Path)
        {
            LoadFile(path);
        }

        public List<Cat> GetAll()
        {
            return _cats;
        }

        public void Add(Cat cat)
        {
            _cats.Add(cat);
            SaveFile(Path);
        }


        //denne metode skal kaldes hver gang vi gerne vil trække data fra vores JSON
        private void LoadFile()
        {
            string json = File.ReadAllText(Path);

            _cats = JsonSerializer.Deserialize<List<Cat>>(json);
        }

        //denne metode skal kaldes når vi vil putte data i vores JSON
        private void SaveFile()
        {

            File.WriteAllText(Path, JsonSerializer.Serialize(_cats));
        }
    }
}
