using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IBlogJSONRepo
    {
        public void Add(Blog blog);
        public List<Blog> GetAll();

        public void Delete(string title);
       
    }
}
