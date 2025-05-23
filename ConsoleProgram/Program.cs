using System.Text.Json;
using Lib.Services;
using Lib.Model;
using Lib.Repo;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Drawing;

//using I_Lib_For_The_Dyreinternat.Model;
//using I_Lib_For_The_Dyreinternat.Repo;
namespace ConsoleProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CostumerService costumerService = new CostumerService();
            PersonJSONRepo personJSONRepo = new PersonJSONRepo();
            WorkerJSONRepo workerJSONRepo = new WorkerJSONRepo(personJSONRepo);
            WorkerService workerService = new WorkerService(workerJSONRepo);
            BlogService blogService = new BlogService(new BlogJSONRepo());
            CatJSONRepo catJSONRepo = new CatJSONRepo();
            DogJSONRepo dogJSONRepo = new DogJSONRepo();
            CostumerJSONRepo costumerJSONRepo= new CostumerJSONRepo(personJSONRepo); 
            AnimalRepo animalRepo = new AnimalRepo(catJSONRepo, dogJSONRepo);
            EventJSONRepo eventRepo = new EventJSONRepo(animalRepo, costumerJSONRepo, workerJSONRepo);
            CatService catService = new CatService(catJSONRepo);
            DogService dogService = new DogService(dogJSONRepo);
            AnimalService animalService = new AnimalService(animalRepo);
            ActivityService activityService = new ActivityService(new ActivityJSONRepo(eventRepo));
            BookingService bookingService = new BookingService(new BookingJSONRepo(eventRepo));
            VeterinarianService vetService = new VeterinarianService(new VeterinarianJSONRepo(eventRepo));
            bool testing = true;
            while (testing == true)
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
                Console.WriteLine();
                Console.Write("Indsæt dit valg: ");
                int choice = ChoiceChoser();



                switch (choice)
                {
                    case 1:
                        testing = false;
                        break;
                    case 2:
                        Console.WriteLine("Hvad ville du teste med Dyr?");
                        Animals(animalService, catService, dogService);
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
        public static void Animals(AnimalService animalService, CatService catService, DogService dogService)
        {
            Console.WriteLine("1. Se alle dyr");
            Console.WriteLine("2. Skabe et nyt dyr");
            Console.WriteLine("3. Se dyr ved at angive ChipID");
            Console.WriteLine("4. Se log fra dyr ved at angive ChipID");
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

                    Console.Write("Indsæt dit valg:");
                    choice = ChoiceChoser();
                    switch (choice)
                    {
                        case 1:
                            AddCat(catService, animalService);
                            break;
                        case 2:
                            AddDog(dogService, animalService);
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Venligst skriv ID'et på det dyr du gerne vil se");
                    GetAnimalByID(animalService);
                    break;
                case 4:
                    Console.WriteLine("Venligst skriv ID'et på det dyr du gerne vil se loggen på");
                    break;


            }


        }
        public static void GetLogByID(AnimalService animalService)
        {
            string chipID = Console.ReadLine();
            List<Event> logs = new List<Event>();
            try
            {
                logs=animalService.GetLogs(chipID);
            }
            catch {
                Console.WriteLine("skriv venligst et valid ID");
                GetLogByID(animalService);
            }

        }
        public static void GetAnimalByID(AnimalService animalService)
        {
            string chipID = Console.ReadLine();
            Animal theanimal = new Animal();
            try
            {
                
                theanimal=animalService.GetByID(chipID);
            }
            catch
            {
                Console.WriteLine("skriv et valid ID");
                GetAnimalByID(animalService);
            }
 
        }

        public static Animal MakeAnimal(AnimalService animalService)
        {
            Console.WriteLine("Hvad skal dyret hede?");
            string name = Console.ReadLine();
            Console.WriteLine("Hvad er dyrets kendetegn");
            string characteristics = Console.ReadLine();
            Console.WriteLine("Hvad er dyrets Status");
            string status = Console.ReadLine();
            bool male = true;
            Console.WriteLine("Er dyret hankøn(ja/nej)");

            checksYesNo(male);
            Console.WriteLine("Er dyret steriliseret?(ja/nej)");
            bool fertile=true;
            checksYesNo(fertile);
            fertile = !fertile;
            Console.WriteLine("Beskriv dyret");
            string description = Console.ReadLine();



            List<Event> events = new List<Event>();

            Console.WriteLine("What størrelse er dyret? (Lille, Medium, Stor)");
            Sizes size = new Sizes();
            RoleChoser();


            void RoleChoser(){

                string roleChoice = Console.ReadLine();
                try
                {
                    switch (roleChoice)
                    {
                        case "Lille" or "lille":
                            size = Sizes.Small;
                            break;
                        case "Medium" or "medium":
                            size = Sizes.Medium;
                            break;
                        case "Stor" or "stor":
                            size = Sizes.Big;
                            break;
                    }
                }
                catch {
                    Console.WriteLine("Venligst brug en af de anerkendte størrelser(lille, medium, stor)");
                    RoleChoser();
                }
            }
            Console.WriteLine("Skriv et valid chipID(chipID kan ikke allerede være i brug af et andet dyr)");
            string chipID = "a";

            List<Animal> animals=animalService.GetAll();
            ValidChipID();
            void ValidChipID()
            {
                chipID = Console.ReadLine();
                foreach (Animal animal in animals) { 
                if (animal.ChipID == chipID)
                    {
                        Console.WriteLine("Givent chipID: " + chipID + " af dyret " + animal.Name + "Prøv et andet");
                        ValidChipID();
                    }
                }
            }
            List<Event> log = new List<Event>();
            Console.WriteLine("hvilket år er dyret født?");
            int year = 1;
            ValidYear();
            void ValidYear()
            {
                string yearAsString = Console.ReadLine();
                try
                {
                    year = Convert.ToInt32(yearAsString);
                    int currentyear= DateTime.Now.Year;
                    if (year < currentyear - 50)
                    {
                        Console.WriteLine("Ingen af vores dyr kan blive så gamle, prøv igen");
                        ValidYear();
                    }
                    else if (year > currentyear) {
                        Console.WriteLine("dyret kan ikke være født i fremtiden, prøv igen");
                        ValidYear();
                    }
                }
                catch
                {
                    Console.WriteLine("Skriv venligst et valid år(tal)");
                    ValidYear();
                }
            }
            Console.WriteLine("Hvilken måned er dyret født, i tal(fra 1 til 12)");
            int month = 1;
            ValidMonth();
            void ValidMonth()
            {
                string monthAsString=Console.ReadLine();
                try
                {
                    month = Convert.ToInt32(monthAsString);
                    if (month < 1)
                    {
                        Console.WriteLine("Der findes ikke en måned før januar, prøv igen");
                        ValidMonth();
                    }
                    else if (month > 12)
                    {
                        Console.WriteLine("Der er ikke mere end 12 måneder i et år, prøv igen");
                        ValidMonth();
                    }
                }
                catch
                {
                    Console.WriteLine("Skriv venligst en valid måned(tal)");
                    ValidMonth();
                }
            }
            List<int> months31 = [1, 3, 5, 7, 8, 10, 12];
            List<int> months30 = [4, 6, 9, 11];
            int monthamount = 28;
            MonthDates();

            void MonthDates()
            {
                foreach (int thisMonth in months31) { if (month == thisMonth) { monthamount = 31; break; } }
                foreach (int thisMonth in months30) { if (month == thisMonth) { monthamount = 30; break; } }
                if (DateTime.IsLeapYear(year)) { monthamount = 29; }
            }
            Console.WriteLine("Hvilken Dato er dyret født(1 til "+ monthamount);
            string dateAsString = "a";
            int date = 1;
            ValidDates();
            void ValidDates()
            {
                dateAsString=Console.ReadLine();
                try
                {
                    date = Convert.ToInt32(dateAsString);
                    if (date < 1) {
                        Console.WriteLine("Du kan ikke skrive en mindre date end 1");
                        ValidDates();
                    }
                    else if(date>monthamount){
                        Console.WriteLine("Så mange dage er der ikke i månd " + month);
                        ValidDates();
                    }

                }
                catch {
                    Console.WriteLine("Skriv venligst en valid dato(tal)");
                    ValidDates();
                }
                
            }
            DateTime birthdate = new DateTime(year, month, date);

            return new Animal(name, characteristics, status, male, fertile, size, log, chipID, description, birthdate);
            //catService.Add(new Cat(name, characteristics, status, male, fertile, size, events, chipID, description));


        }

        public static void AddDog(DogService dogService, AnimalService animalService) {
            Animal theanimal = MakeAnimal(animalService);
            DogBreeds breed = DogBreeds.Unknown;
            string[] breeds=Enum.GetNames(typeof(DogBreeds));
            Console.WriteLine("Hvilken race er hunden af følgende");
            foreach (string theBreed in breeds)
            {
                Console.WriteLine(theBreed);
            }

            string aBreed = Console.ReadLine();
            try
            {
                //breeds: Unknown,Labrador, Golden_Retriever, Rhodesian_Rigdebag, Saint_Bernards_dog
                switch (aBreed)
                {
                    case "Labrador" or "labrador":
                        breed = DogBreeds.Labrador;
                        break;
                    case "Golden Retriever" or "Golden retriever" or "golden Retriever" or "golden retriever":
                        breed = DogBreeds.Golden_Retriever;
                        break;
                    case "Rhodesian Rigdebag" or "Rhodesian rigdebag" or "rhodesian Rigdebag" or "rhodesian rigdebag":
                        breed = DogBreeds.Rhodesian_Rigdebag;
                        break;
                    case "Saint Bernard" or "Saint bernard" or "saint Bernard" or "saint bernard":
                        breed = DogBreeds.Saint_Bernards_dog;
                        break;
                }

            }
            catch
            {

            }
            string name=theanimal.Name;
            string characteristics=theanimal.Characteristics;
            string status=theanimal.Status;
            bool male = theanimal.Male;
            bool fertile = theanimal.Fertile;
            Sizes size=theanimal.Size;
            List<Event> logs=theanimal.Logs;
            string chipID=theanimal.ChipID;
            string description=theanimal.Description;
            DateTime birthdate=theanimal.Birthdate;
            

            Dog thedog= new Dog(name, characteristics,status,male,fertile,size,logs,chipID,description,birthdate,breed);
            dogService.Add(thedog);



        }

        public static void AddCat(CatService catService, AnimalService animalService)
        {
            Animal theanimal = MakeAnimal(animalService);
            CatBreeds breed = CatBreeds.Unknown;
            string[] breeds = Enum.GetNames(typeof(CatBreeds));
            Console.WriteLine("Hvilken race er katten af følgende");
            foreach (string theBreed in breeds)
            {
                Console.WriteLine(theBreed);
            }

            string aBreed = Console.ReadLine();
            try
            {
                //breeds: Unknown,Labrador, Golden_Retriever, Rhodesian_Rigdebag, Saint_Bernards_dog
                switch (aBreed)
                {
                    case "Norwegian Forest Cat" or "norwegian forest cat":
                        breed = CatBreeds.Norwegian_Forest_Cat;
                        break;
                    case "Siamese" or "siamese":
                        breed = CatBreeds.Siamese;
                        break;
                    case "Maine Coon" or "Maine coon" or "maine Coon" or "maine coon":
                        breed = CatBreeds.Maine_Coon;
                        break;
                    case "Korat" or "korat":
                        breed = CatBreeds.Korat;
                        break;
                }

            }
            catch
            {

            }
            string name = theanimal.Name;
            string characteristics = theanimal.Characteristics;
            string status = theanimal.Status;
            bool male = theanimal.Male;
            bool fertile = theanimal.Fertile;
            Sizes size = theanimal.Size;
            List<Event> logs = theanimal.Logs;
            string chipID = theanimal.ChipID;
            string description = theanimal.Description;
            DateTime birthdate = theanimal.Birthdate;


            Cat thecat = new Cat(name, characteristics, status, male, fertile, size, logs, chipID, description, breed, birthdate);
            catService.Add(thecat);



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
                checksYesNo(thebool);
            }
        }



        public static void CreateBlog(WorkerService workerService, BlogService blogService)
        {
            Console.WriteLine("Write the title");
            string title = Console.ReadLine();
            Console.WriteLine("Write the body text");
            string text = Console.ReadLine();
            Worker author = workerService.GetByID(1);

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
            int id = Convert.ToInt32(Console.ReadLine());

            workerService.Add(new Worker(Roles.Admin, name, id));
            
        }
        

        public void CreateCat(CatService catService)
        {
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


        }



    }
}



