﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    //catbreeds in the system
    public enum CatBreeds {Unknown, Siamese, Norwegian_Forest_Cat, Korat, Maine_Coon }
    public class Cat : Animal
    {
        public CatBreeds Breed;

        public Cat() { }

        public Cat(string name, string characteristics, string status, bool male, bool fertile, Sizes size, List<Event> logs, string chipID, string description, CatBreeds breed=CatBreeds.Unknown, DateTime birthdate=default(DateTime))
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
        public override string ToString()
        {
            return $"Name: {Name}, Characteristics: {Characteristics}, Status: {Status}, IsMale: {Male}, Fertile: {Fertile}, Size: {Size}, ChipID: {ChipID}, Description: {Description}, Birthdate:{Birthdate}, Event amount{Logs.Count}, Breed:{Breed}";
        }

    }
}
