using CarBuilder.DataAccess;
using CarBuilder.Entities;
using CarBuilder.ViewModels.Garage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.Controllers
{
    public class GarageController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            MyDbContext context = new MyDbContext();
            model.Items = context.Garages.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM modell)
        {
            if (!ModelState.IsValid)
                return View(modell);

            MyDbContext context = new MyDbContext();
            
            

            Garagee item = new Garagee();
            Car car = context.Cars.Where(s => s.CarID == modell.CarID).FirstOrDefault();
            Client client = context.Clients.Where(s => s.ClientID == modell.ClientID).FirstOrDefault();
            if (car == null)
            {
                ModelState.AddModelError("AuthenthicationFailed", "A car with such ID doesn't exist!");
                //return RedirectToAction("Index", "Garage");
                return View(modell);
            }

            if(client == null)
            {
                ModelState.AddModelError("AuthenthicationFailed", "A client with such ID doesn't exist!");
                //return RedirectToAction("Index", "Garage");
                return View(modell);
            }
            item.CarID = modell.CarID;
            item.ClientID = modell.ClientID;
            context.Garages.Add(item);
            context.SaveChanges();

            return RedirectToAction("Create", "Garage");
        }

        public IActionResult Delete(int id)
        {
            MyDbContext context = new MyDbContext();
            Garagee item = new Garagee();
            item.GarageID = id;
            EntityEntry entry = context.Entry(item);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();

            return RedirectToAction("Index", "Garage");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MyDbContext context = new MyDbContext();
            Garagee item = context.Garages
                                    .Where(s => s.GarageID == id)
                                    .FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index", "Garage");
            }
            
            EditVM model = new EditVM();
           
            model.GarageID = item.GarageID;
            model.CarID = item.CarID;
            model.ClientID = item.ClientID;
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(EditVM modell)
        {
            if (!ModelState.IsValid)
            {
                return View(modell);
            }
            // save students to database
            MyDbContext context = new MyDbContext();
            
            Garagee item = new Garagee();
            Car car = context.Cars.Where(s => s.CarID == item.CarID).FirstOrDefault();
            Client client = context.Clients.Where(s => s.ClientID == item.ClientID).FirstOrDefault();

            if (car == null)
            {
                ModelState.AddModelError("AuthenthicationFailed", "A car with such ID doesn't exist!");
                //return RedirectToAction("Index", "Garage");
                return View(modell);
            }

            if (client == null)
            {
                ModelState.AddModelError("AuthenthicationFailed", "A client with such ID doesn't exist!");
                //return RedirectToAction("Index", "Garage");
                return View(modell);
            }
            item.GarageID = modell.GarageID;
            item.CarID = modell.CarID;
            item.ClientID = modell.ClientID;
            context.Garages.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Garage");
        }
    }
}
