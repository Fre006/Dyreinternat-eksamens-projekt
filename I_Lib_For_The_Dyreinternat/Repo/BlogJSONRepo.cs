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
    public class BlogJSONRepo : IBlogJSONRepo //Implements the BlogJSONRepo interface
    {
        List<Blog> _blogs = new List<Blog>();
        public BlogJSONRepo() 
        {
            try //This try catch tries to load the file and if it fails it will save a new empty file instead
            {
                LoadFile(); 
            }
            catch 
            {
                //Debug.WriteLine("Failed to Load Blog File");
                SaveFile();
            }

        }
        private string _path = @"Blogs.json"; //We create a default path
        private void LoadFile()
        {
            string json = File.ReadAllText(_path); //Takes the json file a puts it into a single string

            _blogs = JsonSerializer.Deserialize<List<Blog>>(json); //Takes that string and turns it back into c# objects


        }
        private void SaveFile()
        {
            //Debug.WriteLine("Saved file");
            File.WriteAllText(_path, JsonSerializer.Serialize(_blogs)); //Saves our list _blogs in a json file
        }

        public void Add(Blog blog) //Simple add method you give it a blog
        {
           _blogs.Add(blog); // And it adds this blog to the list
            //Debug.WriteLine("Successfully added Blog");
            SaveFile(); //Then we save this list with the newly added object
        }
        public List<Blog> GetAll() 
        {
            return _blogs; //Returns the full list of blog objects
        }

        public void Delete(string title)
        {
            foreach (Blog blog in _blogs) //Looks through the list of blogs and remove the first one with the same title, we should have had an id, but ran out of time
            {
                if (title == blog.Title)
                {
                    _blogs.Remove(blog); //Removes the blog from out private list
                    SaveFile(); //Saves the file after
                    break; //This is here to ensure it only deletes the first object
                           //instead of all the objects with a matching title.
                           //This would not have been a problem had we used ID
                }
            }
        }
        public Blog GetByTitle(string title)
        {
            foreach (Blog blog in _blogs) //Looks through all blogs 
            {
                if (blog.Title == title) //and returns the first one with the same title
                {
                    return blog; 
                }
            }
            return null; //If it fails to find one it will just return null

        }

        public void Edit(Blog blog, Blog changedBlog) //You give it the blog you want to edit, and the blog you want to change it into
        {
            foreach (Blog b in _blogs)
            {
                if (b.Title == blog.Title) //Checks for a blog object with a matching title
                {
                    b.Title = changedBlog.Title;            //Changes all the properties one by one
                    b.Text = changedBlog.Text;              //As this is a foreach loop we can not
                    b.Multimedia = changedBlog.Multimedia;  //Directly do b = changedBlog
                    b.Author = changedBlog.Author;
                    //Debug.WriteLine("Edit: "+b);
                    SaveFile();                             //Saves the file
                }
            }
        }
    }
}
