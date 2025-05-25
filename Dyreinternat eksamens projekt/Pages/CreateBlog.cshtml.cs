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
        /*
            Creates some properties for the blogs so we have
            somewhere to trow the variables defined in the html page to
         */
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
        public Roles roleSelect { get; set; }
        [BindProperty]
        public Blog SpecificBlog { get; set; } = new Blog();
        public List<Blog> Blogs { get; set; }
        public List<Worker> Workers { get; set; }

        BlogService _blogService;
        WorkerService _workerService;
        /*
            We create the workerService and BlogServiec and define it so we can 
            Call the methods defined in WorkerService and BlogService.
            We also make sure to get all of the already existing Blogs and workers
            and put them into a list so we can display the blogs.
            Then we reverse the list so the newest one is the first one to show up.
            But since this is done in the constructor everytime you refresh the page
            it flips the list and when you add an object it will be in the incorrect location
            A better option would be using a sorting algorithm to sort by DateTime they were created
            But we ran out of time
         */
        public CreateBlogModel(BlogService bs, WorkerService ws)
        {
            _blogService = bs;
            _workerService = ws;
            
            Blogs = _blogService.GetAll();
            Workers = _workerService.GetAll();
            Blogs.Reverse();
        }


        public void OnPost()
        {

        }
        /*
            When you create a blog it checks whether the author
            is a valid worker. This is why we needed to getAll workers.
            If the author is not a valid worker then we just give it 
            the default worker, John Doe. This is to ensure it is always
            created with a valid worker. Then we give the blog a 
            DateTime.Now and send it down into the repo
         */
        public void OnPostCreate()
        {
            Debug.WriteLine(roleSelect);
            foreach (Worker w in Workers) 
            {
                if (AuthorName == w.Name)
                {
                    Author = w;
                    //Author = _workerService.GetByName(AuthorName);
                }
                else
                {
                    Author = new Worker(Roles.Admin, "John Doe");
                }
            }
            

            Blog blog = new Blog(Title, Text, Author, DateTime.Now);
            //Debug.WriteLine(blog);
            _blogService.Add(blog);

        }
        /*
           This is no longer used 
         */
        //public void OnPostEdit() 
        //{
        //    Debug.WriteLine(SpecificBlog.Title);
        //    Debug.WriteLine(TempTitle);
        //}

        /*
            When you press the show button it redirects
            you to a new page called Blog and sends over 
            the Title of the blog you clicked from
         */
        public IActionResult OnPostShow()
        {
            return RedirectToPage("/Blog", new { Title = TempTitle});
        }
        public void OnGet()
        {
            //Debug.WriteLine(SpecificBlog.Title);
        }
        /*
           No longer used here 
         */
        //public void OnPostDelete()
        //{
        //    _blogService.Delete(Title);
        //}
    }
}
