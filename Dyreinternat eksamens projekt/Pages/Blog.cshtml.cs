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
        public BlogModel(BlogService bs, WorkerService ws)
        {
            _blogService = bs;
            _workerService = ws;
        }

        public IActionResult OnPostDelete()
        {
            _blogService.Delete(TempTitle);
            return RedirectToPage("/CreateBlog");
        }

        public void OnPostEdit()
        {
            Edit = true;
            Author = _workerService.GetByName(AuthorName);
            //SpecificBlog.Author = Author;
            Debug.WriteLine(Author);

        }

        public void OnPostSave(string oldTitle)
        {
            Debug.WriteLine("Old Title: " + oldTitle);

            Blog oldBlog = _blogService.GetByTitle(oldTitle);
            Blog changedBlog = new();
            changedBlog.Title = Title;
            changedBlog.Text = Text;
            changedBlog.Author = _workerService.GetByName(AuthorName);

            Debug.WriteLine(changedBlog);
            //_workerService.Add(new(Roles.Grunt, "FISH"));
            //changedBlog.Author = _workerService.GetByName("FISH");

            _blogService.Edit(oldBlog, changedBlog);
            SpecificBlog = changedBlog;


            Edit = false;
        }


        public void OnGet(string title)
        {
            //Debug.WriteLine("Hello: " + title);

            SpecificBlog = _blogService.GetByTitle(title);
        }
    }
}
