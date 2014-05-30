using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NerdDinner.Model;

namespace NerdDinner.Models
{
    public class SqlDinnerRepository : IDinnerRepository
    {
        DB db;
        public SqlDinnerRepository()
        {
            db = new DB();
        }

        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinners;
        }

        public Dinner GetDinner(int id)
        {
            return db.Dinners.SingleOrDefault(x => x.DinnerId == id);
        }

        public void Add(Dinner dinner)
        {
            db.Dinners.InsertOnSubmit(dinner);
            db.SubmitChanges();
        }

        public void Update(Dinner dinner)
        {
            db.SubmitChanges();
        }

        public void Delete(Dinner dinner)
        {
            db.Dinners.DeleteOnSubmit(dinner);
            db.SubmitChanges();
        }

        public void Add(RSVP rsvp)
        {          
            db.RSVPs.InsertOnSubmit(rsvp);
            db.SubmitChanges();
        }

        public void Update(RSVP rsvp)
        {
            db.SubmitChanges();
        }

        public void Delete(RSVP rsvp)
        {
            db.RSVPs.DeleteOnSubmit(rsvp);
            db.SubmitChanges();
        }

        public RSVP GetRSVP(int id)
        {
            return db.RSVPs.SingleOrDefault(x => x.RsvpId == id);
        }
    }
}