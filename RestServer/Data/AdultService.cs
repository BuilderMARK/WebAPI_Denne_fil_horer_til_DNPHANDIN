﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestServer.Data
{
    public class AdultService : IAdultService
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultService()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WriteAdultsToFile();
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }
        
        private void Seed()
        {
            Adult[] ad =
            {
                new Adult
                {
                    Id = 1,
                    FirstName = "Siyu",
                    LastName = "Xia",
                    HairColor = "Black",
                    EyeColor = "Brown",
                    Age = 21,
                    Weight = 66,
                    Height = 173,
                    Sex = "M",
                    JobTitle = "Student",
                    Salary = 100
                },

                new Adult
                {
                    Id = 2,
                    FirstName = "Baby",
                    LastName = "Girl",
                    HairColor = "Black",
                    EyeColor = "Brown",
                    Age = 1,
                    Weight = 2,
                    Height = 33,
                    Sex = "F",
                    JobTitle = null,
                    Salary = 0
                },
            };
            adults = ad.ToList();
        }

        public async Task<IList<Adult>> ReadAllAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        

        public async Task<Adult> UpdateAdult(Adult updateAdult)
        {
            Adult toUpdate = adults.FirstOrDefault(t => t.Id == updateAdult.Id);
            if (toUpdate == null) throw new Exception($"Did not find adult with id: {updateAdult.Id}");
            toUpdate.FirstName = updateAdult.FirstName;
            toUpdate.LastName = updateAdult.LastName;
            toUpdate.HairColor = updateAdult.HairColor;
            toUpdate.EyeColor = updateAdult.EyeColor;
            toUpdate.Age = updateAdult.Age;
            toUpdate.Weight = updateAdult.Weight;
            toUpdate.Height = updateAdult.Height;
            toUpdate.Sex = updateAdult.Sex;
            toUpdate.JobTitle = updateAdult.JobTitle;
            toUpdate.Salary = updateAdult.Salary;
            WriteAdultsToFile();
            return toUpdate;
        }
        

        public async Task<Adult> AddAdult(Adult addAdult)
        {
            int max = adults.Max(adult => adult.Id);
            addAdult.Id = (++max);
            adults.Add(addAdult);
            WriteAdultsToFile();
            return addAdult;
        }

        async Task  IAdultService.DeleteAdult(int deleteAdult)
        {
            Adult remove = adults.First(t => t.Id == deleteAdult);
            adults.Remove(remove);
            WriteAdultsToFile();
        }
        
        private void WriteAdultsToFile()
        {
            string adultAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile,adultAsJson);
        }
    }
}