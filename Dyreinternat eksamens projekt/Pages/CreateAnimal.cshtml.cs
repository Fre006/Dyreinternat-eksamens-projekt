using System.Diagnostics;
using Lib.Model;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace Dyreinternat_eksamens_projekt.Pages
{
    public class CreateAnimalModel : PageModel
    {
        private AnimalService _animalService;
        private DogService _dogService;
        private CatService _catService;

        public List<Animal> animals;

        [BindProperty]
        public string Name {  get; set; }
        [BindProperty]
        public string Characteristics { get; set; }
        [BindProperty]
        public string Status { get; set; }
        [BindProperty]
        public bool Male { get; set; }
        [BindProperty]
        public bool Fertile { get; set; }
        [BindProperty]
        public List<Event> Logs { get; set; }
        [BindProperty]
        public string ChipID { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public DateTime Birthdate { get; set; }
        public CreateAnimalModel(AnimalService animalService, DogService dogService, CatService catService) 
        {
            _animalService = animalService;
            _dogService = dogService;
            _catService = catService;
            animals = _animalService.GetAll();
        }

        public void OnGet()
        {
        }
        public void OnPostDelete()
        {
            _animalService.DeleteByID(ChipID);

        }

        public void OnPostCreateDog()
        {

            Dog dog = new Dog(Name, Characteristics, Status, Male, !Fertile, Sizes.Small, new List<Event>(), ChipID, Description, Birthdate);
            _dogService.Add(dog);

        }
        public void OnPostCreateCat()
        {
            Cat cat = new Cat(Name, Characteristics, Status, Male, !Fertile, Sizes.Small, new List<Event>(), ChipID, Description, CatBreeds.Unknown, Birthdate);
            _catService.Add(cat);
        }
    }
}
