using RestaurantReviewer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantReviewer.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        private RestaurantDBContext db = new RestaurantDBContext();

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Restuarant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantID,Name,Address,Rating")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {

                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(restaurant);
        }
        //GET: Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }
        //POST: Restuarant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,Name,Address,Rating")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {

                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(restaurant);
        }
        //POST: Restuarant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);

        }
    }
}