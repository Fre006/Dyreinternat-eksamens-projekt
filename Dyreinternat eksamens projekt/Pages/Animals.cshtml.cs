using Lib.Services;
using Lib.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dyreinternat_eksamens_projekt.Pages
{
    public class AnimalsModel : PageModel
    {
        [BindProperty]
        public Animal SpecificAnimal { get; set; }
        private AnimalService _animalService;
        public AnimalsModel(AnimalService animalService)
        {
            _animalService = animalService;
        }
        public void OnGet()
        {

        }



    }
}
