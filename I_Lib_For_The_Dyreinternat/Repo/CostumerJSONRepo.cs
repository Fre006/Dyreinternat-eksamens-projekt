using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public class CostumerJSONRepo : ICostumerJSONRepo //Implements the CostumerJSONRepo interface
    {
        private IPersonJSONRepo _personRepo;
        public List<Costumer> _costumer = new List<Costumer>();

        public CostumerJSONRepo(IPersonJSONRepo PersonRepo)
        {
            _personRepo = PersonRepo;
            try //This try catch tries to load the file and if it fails it will save a new empty file instead
            {
                LoadFile();
            }
            catch
            {
                SaveFile();
            }
        }
        //This method loads the file based off of the given path and puts into our private _costumer list
        private void LoadFile()
        {
            string path = "Costumer.json";
            string json = File.ReadAllText(path);

            _costumer = JsonSerializer.Deserialize<List<Costumer>>(json);
        }

        public void Add(Costumer costumer)  //Add method
        {
            int newid = _personRepo.GiveID(costumer.Id); //Creates a new ID
            costumer.Id = newid;        //Gives the costumer object this new ID
            _costumer.Add(costumer);    //Adds the Costumer to the list
            SaveFile();                 //Saves the list
        }
        
        //Saves our list in a json file
        private void SaveFile()
        {
            string path = "Costumer.json";
            File.WriteAllText(path, JsonSerializer.Serialize(_costumer)); //Saves the Costumer List
        }

        public List<Costumer> GetAll()
        {
            return _costumer; //Returns the full list of costumers
        }
        private int GetIndexByID(int ID)
        {
            //returns 0 if chipID isn't found
            int index = 0;
            for (int i = 0; i < _costumer.Count; i++) //Goes through the list
            {
                if (_costumer[i].Id == ID) //If the id equal the given ID
                {
                    index = i; //Set the index to the current iteration
                }
            }
            return index; //Returns the iteration
        }
        public Costumer GetByID(int ID)
        {
            Costumer theCostumer = new Costumer(); //Creates a new costumer
            int index = GetIndexByID(ID); //Gets the index by ID

            if (_costumer[index].Id == ID) //This just checks if we have the correct object
            {
                theCostumer = _costumer[index];
            }
            return theCostumer;

        }
    }
}
