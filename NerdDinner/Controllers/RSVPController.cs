using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Model;

namespace NerdDinner.Controllers
{
    public class RSVPController : Controller
    {

        IDinnerRepository _repository;

        public RSVPController()
        {
            _repository = new SqlDinnerRepository();
        }

        public RSVPController(IDinnerRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /RSVP/
        public ActionResult Index(int id)
        {
            RsvpViewModel RSVPs = new RsvpViewModel();
            RSVPs.DinnerId = id;
            RSVPs.RSVPs = _repository.FindAllDinners().Where(x => x.DinnerId == id).SelectMany(x => x.RSVPs).ToList();
            return View(RSVPs);
        }

        //
        // GET: /RSVP/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /RSVP/Create
        public ActionResult Create(int id)
        {
            RSVP rsvp = new RSVP();
            rsvp.DinnerId = id;
            return View(rsvp);
        }

        //
        // POST: /RSVP/Create
        [HttpPost]
        public ActionResult Create(RSVP rsvp)
        {
            try
            {
                // TODO: Add insert logic here
                //int dinnerId = (int)rsvp.DinnerId;
                //rsvp.Dinner = _repository.GetDinner(dinnerId);
                _repository.Add(rsvp);
                return RedirectToAction("Index", "RSVP", new { id = rsvp.DinnerId });
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /RSVP/Edit/5
        public ActionResult Edit(int id)
        {
            RSVP rsvp = _repository.GetRSVP(id);
            return View(rsvp);
        }

        //
        // POST: /RSVP/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /RSVP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RSVP/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
