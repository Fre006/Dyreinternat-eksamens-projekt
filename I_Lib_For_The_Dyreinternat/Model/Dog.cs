using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lib.Model
{
    //dogbreeds in the system
    public enum DogBreeds {Unknown,Labrador, Golden_Retriever, Rhodesian_Rigdebag, Saint_Bernards_dog}
    public class Dog:Animal
    {
        public DogBreeds Breed;



        public Dog()
        {

        }
        public Dog(string name, string characteristics, string status, bool male, bool fertile, Sizes size, List<Event> logs, string chipID, string description, DateTime birthdate=default(DateTime), DogBreeds breed = DogBreeds.Unknown) { 
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
