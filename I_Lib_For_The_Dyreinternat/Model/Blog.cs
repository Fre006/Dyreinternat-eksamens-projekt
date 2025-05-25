using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Blog
    {
        //Defining a few properties
        public string Title { get; set; }
        public string Text { get; set; }
        public Worker Author { get; set; }
        public string Multimedia { get; set; }
        public DateTime Date { get; set; }
        
        public Blog() { }//Default Constructor

        /*
            We then use constructor scafolding ot allow the creation of blogs with 
            less data, such as no picture
         */
        public Blog(string title, string text, Worker author, DateTime date) :this()
        {
            Title = title;
            Text = text;
            Author = author;
            Date = date;
        }
        public Blog(string title, string text, Worker author, string multimedia, DateTime date) :this(title,text,author,date)
        {
            Multimedia = multimedia;
        }

        public override string ToString() //A simple ToString that gives the title text and author name
        {
            //return $"Title: {Title}  Text: {Text}";
            return $"Title: {Title}  Text: {Text}  Author: {Author.Name}";
        }
    }
}
