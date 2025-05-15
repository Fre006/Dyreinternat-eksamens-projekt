using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Repo;
using Lib.Model;

namespace Lib.Services
{
    internal class BlogService
    {
        private IBlogJSONRepo _blogRepo;
        public BlogService(IBlogJSONRepo blogJSONRepo) 
        { 
            _blogRepo = blogJSONRepo;
        }
        public void Add(Blog blog)
        {
            _blogRepo.Add(blog);

        }
        public List<Blog> GetAll() 
        {
            return _blogRepo.GetAll();
        }

        public void Delete(string title)
        {
            _blogRepo.Delete(title);
        }

    }
}
