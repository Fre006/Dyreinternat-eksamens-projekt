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

            //List<Event> Log= new List<Event>();

            //Cat thecat= new Cat("Buster","dum","kræft",true,true,Sizes.Big,Log,"12345","sort");
            //List<Animal> animals= new List<Animal>();
            //animals.Add(thecat);
            //catService.Add(thecat);
            //List<Costumer> costumers = new List<Costumer>();

            //Costumer costumer = new Costumer("Frodo", "420", "smoke@weed.everyday", "69696969", DateTime.Now, "12");
            //costumers.Add(costumer);
            //Worker worker = new Worker(Roles.Admin,"Bilbo","1");
            //List<Worker> workers= new List<Worker>();
            //workers.Add(worker);
            //TheActivity theActivity= new TheActivity("Se Buster","Kom og se den dumme kat kræft, Buster",69,1,"her",DateTime.Now, DateTime.Now,workers,animals, costumers);
            //activityService.Add(theActivity);
            //List<Event> Logs = catService.GetLogs("12345");

            //foreach (Event @event in Logs)
            //{
            //    Console.WriteLine( @event.ToString() );
            //}

            //DateTime birthDate = new DateTime(2000, 12, 24);
            //Console.WriteLine(birthDate);

            Console.WriteLine("Dyreinternat. Hvad ville du teste?");
            Console.WriteLine("1. Activity");
            Console.WriteLine("2. Booking");
            Console.WriteLine("3. Blog");
            Console.WriteLine("4. Cat");
            Console.WriteLine("5. Dog");
            Console.WriteLine("6. Vetinarien");
            Console.WriteLine("7. Worker");
            Console.Write("Indsæt dit valg: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:

                    break;
                case 2:
                     





                    break;
                case 3:
                    
                    Console.WriteLine("Write the title");
                    string title = Console.ReadLine();
                    Console.WriteLine("Write the body text");
                    string text = Console.ReadLine();
                    Worker author = workerService.GetByID("012845");
                    
                    blogService.Add(new Blog(title, text, author, DateTime.Now));
                    
                    break;
                case 4:
                    List<Event> events = new List<Event>();
                    Console.WriteLine("Write the cats name");
                    string catName = Console.ReadLine();
                    Console.WriteLine("Any unique characteristics");
                    string characteristics = Console.ReadLine();    
                    Console.WriteLine("Status");
                    string status = Console.ReadLine();
                    Console.WriteLine("Gender? (Male/Female)");
                    string gender = Console.ReadLine();
                    bool male = true; //True er default
                    switch (gender)
                    {
                        case "male" or "Male":
                            male = true;
                            break;
                        case "female" or "Female":
                            male = false;
                            break;
                    }
                    Console.WriteLine("Is the cat fertile? (True/False)");
                    bool fertile = bool.Parse(Console.ReadLine());
                    Console.WriteLine("What size it? (");
                    Sizes size = Sizes.Small; //Small er default
           
                    string roleChoice = Console.ReadLine();
                    switch (roleChoice)
                    {
                        case "Small" or "small":
                            size = Sizes.Small;
                            break;
                        case "Medium" or "medium":
                            size = Sizes.Medium;
                            break;
                        case "Big" or "big":
                            size = Sizes.Big;
                            break;
                    }
                    Console.WriteLine("Write the chipID");
                    string chipID = Console.ReadLine();
                    Console.WriteLine("Description");
                    string description = Console.ReadLine();

                    catService.Add(new Cat(catName, characteristics, status, male, fertile, size, events, chipID, description));


                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:
                    Console.WriteLine("Write the role of the woker (Admin/Leader/Grunt");
                    string a = Console.ReadLine();
                    Roles role;
                    switch (a)
                    { 
                        case "Admin" or "admin":
                            role = Roles.Admin;
                            break;
                        case "Leader" or "leader":
                            role = Roles.Leader;
                            break;
                        case "Grunt" or "grunt":
                            role = Roles.Grunt;
                            break;
                    }
                    Console.WriteLine("Write the name of the new worker");
                    string name = Console.ReadLine();
                    Console.WriteLine("Write the new id of the worker");
                    string id = Console.ReadLine();

                    workerService.Add(new Worker(Roles.Admin, name, id));

                    break;
            }

        }
    }
}



