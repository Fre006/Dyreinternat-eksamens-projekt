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

            //Roles a = Roles.Admin;

            DateTime birthDate = new DateTime(2000, 12, 24);
            Console.WriteLine(birthDate);

            workerService.Add(new Worker(Roles.Admin, "Jensen", "2198501", "Jensen@gmail.com", birthDate));
            //workerService.Add(new Worker(Roles.Grunt, "Mikkel", "3641466", "Mikkel@gmail.com", birthDate));
            //workerService.Add(new Worker(Roles.Grunt, "Lars", "46758678", "Lars@gmail.com", birthDate));
            //workerService.Add(new Worker(Roles.Leader, "Mikkel", "3641466", "Mikkel@gmail.com", birthDate));


            List<Worker> workers = workerService.GetAll();
            Console.WriteLine("amount of workers "+workers.Count);


            foreach (Worker worker in workers) 
            {

                Console.WriteLine(worker.Name);
                Console.WriteLine(worker);
            }
            Console.WriteLine("6");


            //workerService.Add();

        }
    }
}


