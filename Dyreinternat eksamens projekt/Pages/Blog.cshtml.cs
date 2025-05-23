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
        public Worker Author { get; set; }
        [BindProperty]
        public string AuthorName { get; set; }

        BlogService _blogService;
        public BlogModel(BlogService bs)
        {
            _blogService = bs;
        }

        public IActionResult OnPostDelete()
        {
            _blogService.Delete(TempTitle);
            return RedirectToPage("/CreateBlog");
        }

        public void OnPostEdit()
        {
            Edit = true;
        }


        public void OnGet(string title)
        {
            //Debug.WriteLine("Hello: " + title);

            SpecificBlog = _blogService.GetByTitle(title);
        }
    }
}
