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
        List<Blog> _blogs = new List<Blog>();
        public BlogJSONRepo() 
        {
            try
            {
                LoadFile();
            }
            catch 
            {
                //Debug.WriteLine("Failed to Load Blog File");
                SaveFile();
            }

        }
        private string _path = @"Blogs.json";
        private void LoadFile()
        {
            string json = File.ReadAllText(_path);

            _blogs = JsonSerializer.Deserialize<List<Blog>>(json);


        }
        private void SaveFile()
        {
            //Debug.WriteLine("Saved file");
            File.WriteAllText(_path, JsonSerializer.Serialize(_blogs));
        }

        public void Add(Blog blog)
        {
           _blogs.Add(blog);
            Debug.WriteLine("Successfully added Blog");
            SaveFile();
        }
        public List<Blog> GetAll()
        {
            return _blogs;
        }

        public void Delete(string title)
        {
            foreach (Blog blog in _blogs) //Looks through the list of blogs and remove the first one with the same title
            {
                if (title == blog.Title)
                {
                    _blogs.Remove(blog);
                    SaveFile(); //Saves the file after
                    break;
                }
            }
        }
        public Blog GetByTitle(string title)
        {
            foreach (Blog blog in _blogs)
            {
                if (blog.Title == title)
                {
                    return blog;
                }
            }
            return null;

        }

        public void Edit(Blog blog, Blog changedBlog)
        {
            foreach (Blog b in _blogs)
            {
                if (b.Title == blog.Title)
                {
                    b.Title = changedBlog.Title;
                    b.Text = changedBlog.Text;
                    b.Multimedia = changedBlog.Multimedia;
                    b.Author = changedBlog.Author;
                    Debug.WriteLine("Edit: "+b);
                    SaveFile();
                }
            }

            //return null;
        }


    }
}
