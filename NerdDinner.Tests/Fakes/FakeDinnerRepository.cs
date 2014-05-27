using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerdDinner.Model;
using NerdDinner.Models;

namespace NerdDinner.Tests.Fakes
{
    class FakeDinnerRepository:IDinnerRepository
    {
        IList<Dinner> dinners;
        public FakeDinnerRepository()
        {
            dinners = new List<Dinner>();
            for (int i = 0; i < 100; i++)
            {
                var dinner = new Dinner();
                dinner.Title = "dinner" + i;
                dinner.Longitude = -100.00;
                dinner.Latitude = 35.00;
                dinner.HostedBy = "Test";
                dinner.EventTime = "After Work";
                dinner.EventDate = DateTime.Now.AddDays(1);

                if (i >= 50)
                {
                    dinner.EventDate = DateTime.Now.AddDays(-1);
                }

                dinner.Description = "Test Dinner";
                dinner.Address = "Address " + i;
                dinner.ContactPhone = "555-5555";

                dinners.Add(dinner);
            }
            
        }

        public void Add(Dinner dinner)
        {
            dinners.Add(dinner);
        }

        public IQueryable<Dinner> FindAllDinners()
        {
            return dinners.AsQueryable();
        }

        public Dinner GetDinner(int id)
        {
            return FindAllDinners().SingleOrDefault(x => x.DinnerId == id);
        }

        public void Update(Dinner dinner)
        {
            var listDinner = GetDinner(dinner.DinnerId);
            Delete(listDinner);
            Add(dinner);
        }

        public void Delete(Dinner dinner)
        {
            var listDinner = GetDinner(dinner.DinnerId);
            dinners.Remove(listDinner);
        }
    }
}
