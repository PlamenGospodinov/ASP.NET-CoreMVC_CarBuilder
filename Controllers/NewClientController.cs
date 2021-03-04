using CarBuilder.DataAccess;
using CarBuilder.Entities;
using CarBuilder.ViewModels.NewClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.Controllers
{
    public class NewClientController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            MyDbContext context = new MyDbContext();
            model.Items = context.Clients.ToList();
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

            Client item = new Client();
            Client client = context.Clients.Where(s => s.ClientID == modell.ClientID).FirstOrDefault();
            item.ClientID = modell.ClientID;
            item.FirstName = modell.FirstName;
            item.LastName = modell.LastName;
            item.City = modell.City;
            
            if (client == null)
            {
                context.Clients.Add(item);
                context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("AuthenthicationFailed", "A client with such ID already exists!");
                //return RedirectToAction("Index", "Garage");
                return View(modell);
            }
            return RedirectToAction("Create", "NewClient");
        }

        public IActionResult Delete(string id)
        {
            MyDbContext context = new MyDbContext();
            Client item = new Client();
            item.ClientID = id;
            EntityEntry entry = context.Entry(item);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();

            return RedirectToAction("Index", "NewClient");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            MyDbContext context = new MyDbContext();
            Client item = context.Clients
                                    .Where(s => s.ClientID == id)
                                    .FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index", "NewCar");
            }
            EditVM model = new EditVM();
            
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.City = item.City;
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
            Client item = new Client();
            item.FirstName = modell.FirstName;
            item.LastName = modell.LastName;
            item.City = modell.City;
            

            context.Clients.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "NewClient");
        }
    }
}
