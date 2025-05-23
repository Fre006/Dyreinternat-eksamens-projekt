﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Repo;
using Lib.Services;

namespace Lib.Repo
{
    public class AnimalRepo:IAnimalRepo
    {
        protected List<Animal> _animals = new List<Animal>();
        private List<Cat> _cats= new List<Cat>();
        private List<Dog> _dogs = new List<Dog>();
        private ICatJSONRepo _catRepo;
        private IDogJSONRepo _dogRepo;
        public AnimalRepo(ICatJSONRepo CatRepo, IDogJSONRepo DogRepo) {
            _catRepo = CatRepo;
            _dogRepo = DogRepo;
            UpdateAnimals();

        }
        //simply Updates the _animals list then returns it
        public List<Animal> GetAll()
        {
            UpdateAnimals();
            return _animals;
        }
        //uses cat and dog repos, to get a list of all animals
        internal void UpdateAnimals()
        {
            _animals = new List<Animal>();
            _cats = _catRepo.GetAll();
            _dogs = _dogRepo.GetAll();
            foreach (Cat cat in _cats)
            {
                _animals.Add(cat);
            }
            foreach (Dog dog in _dogs)
            {
                _animals.Add(dog);
            }
        }
        //just an internal method to get animal indexes via ID's 
        internal int GetIndexByID(string chipID)
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
        //uses GetByID then just returns that animals log
        public List<Event> GetLogs(string chipID)
        {

            Animal theanimal = GetByID(chipID);
            return theanimal.Logs; ;
        }
        //tries to add the event to both dogs and cats, which then checks wether that dog
        //or cat exists in the dog/cat repo and if it exists then it adds the event to the log
        public void AddLog(string chipID, Event newEntry, string path = "default")
        {
            try
            {
                _dogRepo.AddLog(chipID, newEntry, path);
            }
            catch
            {

            }
            try
            {
                _catRepo.AddLog(chipID, newEntry, path);
            }
            catch
            {

            }

        }
        //first uses UpdateAnimals just in case, then uses get index by ID,
        //then checks if the index matches the id, in case it returned the right animal
        //and if it did, returns that animal else returns a null animal
        public Animal GetByID(string chipID)
        {
            UpdateAnimals();
            Animal theanimal = new Animal();
            int index = GetIndexByID(chipID);

            if (_animals[index].ChipID == chipID)
            {
                theanimal = _animals[index];
            }
            return theanimal;

        }

        //Takes an Event, and chipID of animal,
        //foreach Animal in the event, sends the event ID and chipID to
        //RemoveLogByID in dog and catrepo
        public void RemoveLogByID(Event theEvent, string chipID)
        {
            foreach (Animal theAnimal in theEvent.Animals)
            {
                try { _catRepo.RemoveLogByID(theEvent.ID, chipID); }
                catch { }
                try { _dogRepo.RemoveLogByID(theEvent.ID, chipID); }
                catch { }
            }
        }
        //Takes and for each animal in the event, sends theEvent id and
        //each animals to cat and dog repos remove log by id
        public void DeletedEvent(Event theEvent)
        {
            foreach (Animal theAnimal in theEvent.Animals)
            {
                try { _catRepo.RemoveLogByID(theEvent.ID, theAnimal.ChipID); }
                catch { }
                try { _dogRepo.RemoveLogByID(theEvent.ID, theAnimal.ChipID); }
                catch { }
            }
        }
        //Sends Chip id to both deletebyid for catrepo and dogrepos deletebyid
        public void DeleteByID(string chipID)
        {
            try { _catRepo.DeleteByID(chipID); }
            catch { }
            try { _dogRepo.DeleteByID(chipID); }
            catch { }
        }
        //Sends chipID to both cat and dog repos sterilize function
        public void Sterilise(string chipID, string path = "default")
        {
            try
            {
                _catRepo.Sterilise(chipID);
            }
            catch { }
            try
            {
                _catRepo.Sterilise(chipID);
            }
            catch { }

        }
        //Filters all animals for males:
        public List<Animal> AllMales()
        {
            List<Animal> males = new List<Animal>();
            foreach(Animal theanimal in _animals)
            {
                if (theanimal.Male)
                {
                    males.Add(theanimal);
                }
            }
            return males;
        }
        //Filters all animals for females:
        public List<Animal> AllFemales()
        {
            List<Animal> females = new List<Animal>();
            foreach (Animal theanimal in _animals)
            {
                if (!theanimal.Male)
                {
                    females.Add(theanimal);
                }
            }
            return females;
        }
        //Filters all animals for fertile:
        public List<Animal> AllFertile()
        {
            List<Animal> fertile = new List<Animal>();
            foreach (Animal theanimal in _animals)
            {
                if (theanimal.Fertile)
                {
                    fertile.Add(theanimal);
                }
            }
            return fertile;
        }
        //Filters all animals for infertile:
        public List<Animal> AllInfertile()
        {
            List<Animal> infertile = new List<Animal>();
            foreach (Animal theanimal in _animals)
            {
                if (!theanimal.Fertile)
                {
                    infertile.Add(theanimal);
                }
            }
            return infertile;
        }


    }
}
