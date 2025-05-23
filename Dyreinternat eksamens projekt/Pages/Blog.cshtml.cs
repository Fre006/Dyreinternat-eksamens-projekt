using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lib.Model;
using Lib.Repo;
using Lib.Services;
using Dyreinternat_eksamens_projekt.Pages;

namespace Dyreinternat_eksamens_projekt.Pages
{
    public class BlogModel : PageModel
    {
        //public Blog SpecificBlog;

        BlogService _blogService;
        public void OnGet(BlogService bs)
        {
            _blogService = bs;
        }
    }
}
