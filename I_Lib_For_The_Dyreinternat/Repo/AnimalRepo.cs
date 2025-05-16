using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;
using Lib.Services;

namespace Lib.Repo
{
    internal class AnimalRepo:IAnimalRepo
    {
        protected List<Animal> _animals = new List<Animal>();
        private List<Cat> _cats= new List<Cat>();
        private List<Dog> _dogs = new List<Dog>();
        private ICatRepo _catRepo;
        private IDogRepo _dogRepo;
        public AnimalRepo(ICatRepo CatRepo, IDogRepo DogRepo) {
            _catRepo = CatRepo;
            _cats = _catRepo.GetAll();
            _dogRepo = DogRepo;
            _dogs = _dogRepo.GetAll();
            foreach (Cat cat in _cats) { 
                _animals.Add(cat);
            }
            foreach (Dog dog in _dogs)
            {
                _animals.Add(dog);
            }
        }
        public List<Animal> GetAll()
        {
            return _animals;
        }

        public int GetIndexByID(string chipID)
        {
            //returns 0 if chipID isn't found
            int index = 0;
            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].ChipID == chipID)
                {

                    index = i;

                }
            }
            return index;
        }

        public List<Event> GetLogs(string chipID)
        {
            Animal theanimal = GetByID(chipID);
            return theanimal.Logs; ;
        }
        public void AddLog(string chipID, Event newEntry, string path = "default")
        {
            _dogRepo.AddLog(chipID, newEntry, path);
            _catRepo.AddLog(chipID, newEntry, path);
        }

        public Animal GetByID(string chipID)
        {
            Animal theanimal = new Animal();
            int index = GetIndexByID(chipID);

            if (_animals[index].ChipID == chipID)
            {
                theanimal = _animals[index];
            }
            return theanimal;

        }




    }
}
