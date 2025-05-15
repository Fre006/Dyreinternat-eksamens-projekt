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

        public Cat(CatBreeds breed)
        {
            Breed = breed;
        }

    }
}
