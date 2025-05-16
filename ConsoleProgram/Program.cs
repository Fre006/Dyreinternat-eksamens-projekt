using System.Text.Json;
using Lib.Services;
using Lib.Model;
using Lib.Repo;
using System.Data;
using System.Security.Cryptography.X509Certificates;

//using I_Lib_For_The_Dyreinternat.Model;
//using I_Lib_For_The_Dyreinternat.Repo;
namespace ConsoleProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkerService workerService = new WorkerService(new WorkerJSONRepo());
            BlogService blogService = new BlogService(new BlogJSONRepo());


            DateTime birthDate = new DateTime(2000, 12, 24);
            Console.WriteLine(birthDate);

            //workerService.Add(new Worker(Roles.Admin, "Jensen", "2198501","2414121", "Jensen@gmail.com", birthDate));
            //workerService.Add(new Worker(Roles.Grunt, "Mikkel", "3641466", "Mikkel@gmail.com", birthDate));
            //workerService.Add(new Worker(Roles.Grunt, "Lars", "46758678", "2412414", "Lars@gmail.com", birthDate));
            //workerService.Add(new Worker(Roles.Leader, "Mikkel", "3641466", "Mikkel@gmail.com", birthDate));


            Worker a = new Worker();

            List<Worker> workers = workerService.GetAll();
            Console.WriteLine("amount of workers "+workers.Count);
            
            //for (int i = 0; i < workers.Count; i++) 
            //{ 
            //    if (workers[i].Name == "Lars")
            //    {
            //        a = workers[i];
            //    }
            //}

            //blogService.Add(new Blog("Fishing with the boys", "We are going fishing", a, "" ,DateTime.Now));

            List<Blog> blogs = new List<Blog>();
            blogs = blogService.GetAll();

            blogService.Delete("Fishing with the boys");

            foreach (Worker worker in workers) 
            {

                //Console.WriteLine(worker.Name);
                Console.WriteLine(worker);
            }
            foreach (Blog blog in blogs) 
            {
                Console.WriteLine(blog);
            }
            
                //Console.WriteLine(blogs[1].Title);
                //Console.WriteLine(blogs[1].Text);
                //Console.WriteLine("Written By: "+ blogs[1].Author.Name);
        }
    }
}



