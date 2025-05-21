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
            BookingService bookingService = new BookingService(new BookingJSONRepo(eventRepo));
            VeterinarianService vetService = new VeterinarianService(new VeterinarianJSONRepo(eventRepo));
            bool testing = true;
            while (testing)
            {
                testClient();
            }
            void testClient()
            {
                Console.WriteLine("Hvad vil du gerne teste?");
                Console.WriteLine("1. Slut test");
                Console.WriteLine("2. Dyr");
                Console.WriteLine("3. Blog");
                Console.WriteLine("4. Worker");
                Console.WriteLine("5. Event");
                Console.Write("Indsæt dit valg: ");
                int choice = ChoiceChoser();



                switch (choice)
                {
                    case 1:
                        testing = false;
                        break;
                    case 2:
                        Console.WriteLine("Hvad ville du teste med Dyr?");
                        Animals(animalService);
                        break;
                    case 3:
                        CreateBlog(workerService, blogService);
                        break;
                    case 4:
                        CreateWorker(workerService);
                        break;

                    case 5:
                        break;
                }
            }


        }
        public static int ChoiceChoser()
        {
            int choice = new int();
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Du skal skrive et nummer");
                Console.Write("Indsæt dit valg: ");
                ChoiceChoser();
            }
            return choice;

        }
        public static void Animals(AnimalService animalService)
        {
            Console.WriteLine("1. Se alle dyr");
            Console.WriteLine("2. Skabe et nyt dyr");
            Console.Write("Indsæt dit valg: ");

            int choice = ChoiceChoser();



            switch (choice)
            {
                case 1:
                    foreach (Animal animal in animalService.GetAll())
                    {
                        Console.WriteLine(animal.ToString());
                    }

                    break;
                case 2:
                    Console.WriteLine("hvilket dyr vil du lave?");
                    Console.WriteLine("1. Kat");
                    Console.WriteLine("2. Hund");
                    choice = ChoiceChoser();
                    switch (choice)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                    }

                    break;
            }

        }
        public static void MakeAnimal()
        {
            Console.WriteLine("Hvad skal dyret hede?");
            string name = Console.ReadLine();
            Console.WriteLine("Hvad er dyret kendetegn");
            string characteristics = Console.ReadLine();
            Console.WriteLine("Hvad er dyret Status");
            string status = Console.ReadLine();
            bool male = true;
            Console.WriteLine("Er dyret hankøn(ja/nej)");

            checksYesNo(male);
            Console.WriteLine("Er dyret steriliseret?(ja/nej)");
            bool fertile=true;
            checksYesNo(fertile);
            Console.WriteLine("Beskriv dyret");
            string description = Console.ReadLine();




            //Animal anAnimal= new Animal(name, characteristics, status, male,);

            

        }

        public static void checksYesNo(bool thebool)
        {
            string yesNo = Console.ReadLine();
            if (yesNo == "ja")
            {

            }
            else if (yesNo == "nej")
            {
                    thebool = false;
            }
            else
            {
                    Console.WriteLine("Vær venlig at skrive ja eller nej");
                    yesNo = Console.ReadLine();
                    checksYesNo(thebool);
            }
        }
                


        public static void CreateBlog(WorkerService workerService, BlogService blogService)
        {
        Console.WriteLine("Write the title");
        string title = Console.ReadLine();
        Console.WriteLine("Write the body text");
        string text = Console.ReadLine();
        Worker author = workerService.GetByID("012845");

        blogService.Add(new Blog(title, text, author, DateTime.Now));

        }
        public static void CreateWorker(WorkerService workerService)
        {
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

            
       
            
        }


    }
}



