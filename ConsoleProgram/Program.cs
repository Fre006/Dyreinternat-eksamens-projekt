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
            CatJSONRepo catJSONRepo = new CatJSONRepo();
            DogJSONRepo dogJSONRepo = new DogJSONRepo();
            CatService catService = new CatService(catJSONRepo);
            DogService dogService = new DogService(dogJSONRepo);
            AnimalService animalService = new AnimalService(new AnimalRepo(catJSONRepo, dogJSONRepo));


            DateTime birthDate = new DateTime(2000, 12, 24);
            Console.WriteLine(birthDate);


        }
    }
}



