using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lib.Repo;
using Lib.Model;
using Lib.Services;
using System.Diagnostics;


namespace Dyreinternat_eksamens_projekt.Pages
{
    public class CreateBlogModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string TempTitle { get; set; }
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public Worker Author { get; set; }
        [BindProperty]
        public string AuthorName { get; set; }
        [BindProperty]
        public Blog SpecificBlog { get; set; } = new Blog();
        public List<Blog> Blogs { get; set; }

        BlogService _blogService;
        WorkerService _workerService;

        public CreateBlogModel(BlogService bs, WorkerService ws)
        {
            _blogService = bs;
            _workerService = ws;
            Blogs = _blogService.GetAll();
        }


        public void OnPost()
        {

        }
        public void OnPostCreate()
        {
            if (AuthorName != null)
            {
                Author = _workerService.GetByName(AuthorName);
            }
            else
            {
                Author = new Worker();
            }

            Blog blog = new Blog(Title, Text, Author, DateTime.Now);
            Debug.WriteLine(blog);
            _blogService.Add(blog);

        }

        public void OnPostEdit() 
        {
            Debug.WriteLine(SpecificBlog.Title);
            Debug.WriteLine(TempTitle);
        }

        public IActionResult OnPostShow()
        {
            return RedirectToPage("/Blog", new { Title = TempTitle});
        }
        public void OnGet()
        {
            //Debug.WriteLine(SpecificBlog.Title);
        }

        public void OnPostDelete()
        {
            _blogService.Delete(Title);
        }
    }
}
