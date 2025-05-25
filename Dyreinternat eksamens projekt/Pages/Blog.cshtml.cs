using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lib.Model;
using Lib.Repo;
using Lib.Services;
using Dyreinternat_eksamens_projekt.Pages;
using System.Diagnostics;
using System.Net.Security;

namespace Dyreinternat_eksamens_projekt.Pages
{
    public class BlogModel : PageModel
    {
        /*
            Creates some properties for the blogs so we have
            somewhere to trow the variables defined in the html page to
            Mainly when using the edit method
         */
        [BindProperty]
        public Blog SpecificBlog { get; set; }
        [BindProperty]
        public string TempTitle { get; set; }
        [BindProperty]
        public bool Edit { get; set; } = false;
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public Worker Author { get; set; } = new Worker();
        [BindProperty]
        public string AuthorName { get; set; }

        private BlogService _blogService;
        private WorkerService _workerService;

        /*
            We create the workerService and BlogServiec and define it so we can 
            Call the methods defined in WorkerService and BlogService.
         */


        public BlogModel(BlogService bs, WorkerService ws)
        {
            _blogService = bs;
            _workerService = ws;
        }

        /*
            The delete button deletes the blog based of title
            and then redirects you back to the CreatePage you came from
        */

        public IActionResult OnPostDelete()
        {
            _blogService.Delete(TempTitle);
            return RedirectToPage("/CreateBlog");
        }

        /*
            The edit method sets our bool Edit to true so that the 
            Page can change how it looks
            It
        */

        public void OnPostEdit()
        {
            Edit = true;
            //Author = _workerService.GetByName(AuthorName);
            //SpecificBlog.Author = Author;
            //Debug.WriteLine(Author);

        }
        /*
            The save method is what actually changes things
            We create a new blog called changedBlog and change 
            all of it's properties to be the ones defined in text
            fields over on the html web page and use our edit method
            When using this method we also send the old title, just in
            case we changed it, and get the original object in the repo
            and send it back down so the edit method knows what object it 
            is meant to change
        */
        public void OnPostSave(string oldTitle)
        {
            //Debug.WriteLine("Old Title: " + oldTitle);

            Blog oldBlog = _blogService.GetByTitle(oldTitle);
            Blog changedBlog = new();
            changedBlog.Title = Title;
            changedBlog.Text = Text;
            changedBlog.Author = _workerService.GetByName(AuthorName);

            //Debug.WriteLine(changedBlog);
            //_workerService.Add(new(Roles.Grunt, "FISH"));
            //changedBlog.Author = _workerService.GetByName("FISH");

            _blogService.Edit(oldBlog, changedBlog);
            SpecificBlog = changedBlog;


            Edit = false;
        }


        public void OnGet(string title)
        {
            /*
                Here is the title we send when going to this webpage
                We use this title to get the object so we can display it
            */
            //Debug.WriteLine("Hello: " + title);

            SpecificBlog = _blogService.GetByTitle(title);
        }
    }
}
