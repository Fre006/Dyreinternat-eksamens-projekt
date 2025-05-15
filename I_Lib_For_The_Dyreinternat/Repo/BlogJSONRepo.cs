using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class BlogJSONRepo : IBlogJSONRepo
    {
        List<Blog> blogs = new List<Blog>();
        public BlogJSONRepo() 
        {
            try
            {
                LoadFile();
            }
            catch 
            {
                Debug.WriteLine("Failed to Load File");
                //SaveFile();
            }

        }
        private string _path = @"Blogs.json";
        private void LoadFile()
        {
            string json = File.ReadAllText(_path);
            blogs = JsonSerializer.Deserialize<List<Blog>>(json);

        }
        private void SaveFile()
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(blogs));
        }

        public void Add(Blog blog)
        {
            blogs.Add(blog);
            //Debug.WriteLine("Successfully added Blog");
            SaveFile();
        }
        public List<Blog> GetAll()
        {
            return blogs;
        }

        public void Delete(string title)
        {
            foreach (Blog blog in blogs) 
            {
                if (title == blog.Title)
                {
                    blogs.Remove(blog);
                }
            }

        }


    }
}
