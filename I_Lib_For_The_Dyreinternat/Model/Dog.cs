using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lib.Model
{
    enum DogBreeds { Labrador, Golden_Retriever, Rhodesian_Rigdebag, Saint_Bernards_dog}
    internal class Dog:Animal
    {
        public DogBreeds Breed; 
        public Dog(DogBreeds breed, string name, string characteristics, string status, bool male, bool fertile, Sizes size, List<string> logs, string chipID, string description, DateTime birthdate) { 
            Breed= breed;
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
