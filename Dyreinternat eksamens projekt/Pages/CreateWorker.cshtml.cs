 using Lib.Model;
using Lib.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dyreinternat_eksamens_projekt.Pages
{
    public class CreateWorkerModel : PageModel
    {
        /*
            Creates some properties for the worker so we have
            somewhere to trow the variables defined in the html page to
         */
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public int WorkerID { get; set; }
        [BindProperty]
        public Roles roleSelect { get; set; }


        public List<Worker> Workers { get; set; }

        WorkerService _workerService;
        /*
            We create the workerService and define it so we can 
            Call the methods defined in WorkerService.
            We also make sure to get all of the already existing workers
            and put them into a list so we can display them
         */
        public CreateWorkerModel(WorkerService ws)
        {
            _workerService = ws;
            Workers = _workerService.GetAll();
        }
        public void OnPost()
        {

        }
        /*
            It creates a new worker object and gives it the properties defined by
            the user in the html page and then adds it to the repo using out Add() method
         */
        public void OnPostCreate()
        {

            //Debug.WriteLine(roleSelect);
            Worker worker = new Worker(roleSelect, Name, ID, PhoneNumber);
            //Debug.WriteLine(worker);
            _workerService.Add(worker);

        }
        /*
            Takes the id sent over when pressing the delete button
            Uses out GetById() method to put the worker into an object
            So we can use this temporary object to delete the worker
         */
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
