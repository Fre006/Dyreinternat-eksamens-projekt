using System.Text.Json;
using Lib.Services;
using Lib.Model;
using Lib.Repo;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;

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
            AnimalRepo animalRepo = new AnimalRepo(catJSONRepo, dogJSONRepo);
            EventJSONRepo eventRepo = new EventJSONRepo(animalRepo);
            CatService catService = new CatService(catJSONRepo);
            DogService dogService = new DogService(dogJSONRepo);
            AnimalService animalService = new AnimalService(animalRepo);
            ActivityService activityService = new ActivityService(new ActivityJSONRepo(eventRepo));
            BookingService bookingService= new BookingService(new BookingJSONRepo(eventRepo));
            VeterinarianService vetService= new VeterinarianService(new VeterinarianJSONRepo(eventRepo));

            List<Event> Log= new List<Event>();

            Cat thecat= new Cat("Buster","dum","kræft",true,true,Sizes.Big,Log,"12345","sort");
            List<Animal> animals= new List<Animal>();
            animals.Add(thecat);
            catService.Add(thecat);
            List<Costumer> costumers = new List<Costumer>();

            Costumer costumer = new Costumer("Frodo", "420", "smoke@weed.everyday", "69696969", DateTime.Now, "12");
            costumers.Add(costumer);
            Worker worker = new Worker(Roles.Admin,"Bilbo","1");
            List<Worker> workers= new List<Worker>();
            workers.Add(worker);
            Activity theActivity= new Activity("Se Buster","Kom og se den dumme kat kræft, Buster",69,1,"her",DateTime.Now, DateTime.Now,workers,animals, costumers);
            activityService.Add(theActivity);
            List<Event> Logs = catService.GetLogs("12345");

            foreach (Event @event in Logs)
            {
                Console.WriteLine( @event.ToString() );
            }
            
            DateTime birthDate = new DateTime(2000, 12, 24);
            Console.WriteLine(birthDate);


        }
    }
}



