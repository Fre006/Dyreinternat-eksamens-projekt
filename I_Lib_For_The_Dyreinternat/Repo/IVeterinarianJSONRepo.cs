﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Model;

namespace Lib.Repo
{
    public interface IVeterinarianJSONRepo
    {
        public List<VeterinarianVisit> GetAll();
        public void Add(VeterinarianVisit veterinarian);
        public void Edit(int id, string name, string description, int customerCap, int animalCap, string location, DateTime start, DateTime stop, string veterinarian);
        public List<VeterinarianVisit> GetByName(string name);
        public int GetIndexById(int id);
        public void DeleteById(int id);
        public void RegAnimal(int EventId, string AnimalId);
        public void RegWorker(int EventId, int WorkerId);
        public void DeRegWorker(int EventId, int WorkerId);
        public void DeRegAnimal(int EventId, string AnimalId);
    }
}
