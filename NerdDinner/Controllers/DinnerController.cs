using NerdDinner.Model;
using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class DinnerController : Controller
    {
        IDinnerRepository _repository;

        public DinnerController()
        {
            _repository = new SqlDinnerRepository();
        }

        public DinnerController(IDinnerRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Dinner/
        public ActionResult Index()
        {
            //var db = new DB();
            //var dinners = db.Dinners;
            var dinners = _repository.FindAllDinners();//.Where(x => x.EventDate >= DateTime.Now);

            if (Request.IsAjaxRequest())
            {
                return Json(dinners, JsonRequestBehavior.AllowGet);
            }

            return View(dinners);
        }

        //
        // GET: /Dinner/Details/5
        public ActionResult Details(int id)
        {
            var dinner = _repository.GetDinner(id);
            return View(dinner);
        }

        //
        // GET: /Dinner/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Dinner/Create
        [HttpPost]
        public ActionResult Create(Dinner dinner)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    //var db = new DB();
                    //db.Dinners.InsertOnSubmit(dinner);
                    _repository.Add(dinner);
                    //try
                    //{
                    //    _repository.SubmitChanges();
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine("{0} Exception caught.", e);
                    //}
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(dinner);
                }
            }
            else
            {
                return View(dinner);
            }
        }

        //
        // GET: /Dinner/Edit/5
        public ActionResult Edit(int id)
        {
            //var db = new DB();
            //var dinner = db.Dinners.SingleOrDefault(x => x.DinnerId == id);
            var dinner = _repository.GetDinner(id);
            return View(dinner);
        }

        //
        // POST: /Dinner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //var db = new DB();
            //var dinner = db.Dinners.SingleOrDefault(x => x.DinnerId == id);
            var dinner = _repository.GetDinner(id);
            try
            {
                // TODO: Add update logic here
                //db.SubmitChanges();
                UpdateModel(dinner, collection.ToValueProvider());              
                _repository.Update(dinner);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Dinner/Delete/5
        public ActionResult Delete(int id)
        {
            //var db = new DB();
            //var dinner = db.Dinners.SingleOrDefault(x => x.DinnerId == id);
            var dinner = _repository.GetDinner(id);
            return View(dinner);
        }

        //
        // POST: /Dinner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //var db = new DB();
                //var dinner = db.Dinners.SingleOrDefault(x => x.DinnerId == id);
                var dinner = _repository.GetDinner(id);
                //db.Dinners.DeleteOnSubmit(dinner);
                //db.SubmitChanges();
                _repository.Delete(dinner);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
