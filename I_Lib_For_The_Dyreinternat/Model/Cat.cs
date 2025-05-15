using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    enum CatBreeds { Siamese, Norwegian_Forest_Cat, Korat, Maine_Coon }
    internal class Cat : Animal
    {
        public CatBreeds Breed;

        public Cat() { }

        public Cat(CatBreeds breed, string name, string characteristics, string status, bool male, bool fertile, Sizes size, List<Event> logs, string chipID, string description, DateTime birthdate)
        {
            Breed = breed;
            Name = name;
            Characteristics = characteristics;
            Status = status;
            Male = male;
            Fertile = fertile;
            Size = size;
            ChipID = chipID;
            Description = description;
            Logs = logs;
            ChipID = chipID;
            Birthdate = birthdate;
        }

    }
}
