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
        public Dog(DogBreeds breed) { 
        Breed= breed;
        }


    }
}
