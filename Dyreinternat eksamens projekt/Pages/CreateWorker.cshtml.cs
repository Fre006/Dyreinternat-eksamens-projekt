using Lib.Model;
using Lib.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dyreinternat_eksamens_projekt.Pages
{
    public class CreateWorkerModel : PageModel
    {

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public int WorkerID { get; set; }


        public List<Worker> Workers { get; set; }

        WorkerService _workerService;

        public CreateWorkerModel(WorkerService ws)
        {
            _workerService = ws;
            Workers = _workerService.GetAll();
        }
        public void OnPost()
        {

        }

        public void OnPostCreate()
        {

            Worker worker = new Worker(Roles.Grunt, Name, ID, PhoneNumber);
            Debug.WriteLine(worker);
            _workerService.Add(worker);

        }

        public void OnPostDelete()
        {
            Worker w = _workerService.GetByID(WorkerID);
            //Debug.WriteLine(w);
            _workerService.Delete(w);

        }
        public void OnGet()
        {
        }
    }
}
