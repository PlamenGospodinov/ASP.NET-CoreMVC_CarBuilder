using CarBuilder.DataAccess;
using CarBuilder.Entities;
using CarBuilder.ViewModels.NewCar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.Controllers
{
    public class NewCarController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            MyDbContext context = new MyDbContext();
            model.Items = context.Cars.ToList();
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
            
            Car item = new Car();
            Car car = context.Cars.Where(s => s.CarID == modell.CarID).FirstOrDefault();
            item.CarID = modell.CarID;
            item.Brand = modell.Brand;
            item.Model = modell.Model;
            item.Color = modell.Color;
            item.InteriorMaterial = modell.InteriorMaterial;
            item.InteriorColor = modell.InteriorColor;
            item.EngineDisplacement = modell.EngineDisplacement;
            if(car == null)
            {
                context.Cars.Add(item);
                context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("AuthenthicationFailed", "A car with such ID already exists!");
                //return RedirectToAction("Index", "Garage");
                return View(modell);
            }
            
            
            return RedirectToAction("Create", "NewCar");
        }

        public IActionResult Delete(string id)
        {
            MyDbContext context = new MyDbContext();
            Car item = new Car();
            item.CarID = id;
            EntityEntry entry = context.Entry(item);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();

            return RedirectToAction("Index","NewCar");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            MyDbContext context = new MyDbContext();
            Car item = context.Cars
                                    .Where(s => s.CarID == id)
                                    .FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index", "NewCar");
            }
            EditVM model = new EditVM();
            
            model.Brand = item.Brand;
            model.Model = item.Model;
            model.Color = item.Color;
            model.InteriorMaterial = item.InteriorMaterial;
            model.InteriorColor = item.InteriorColor;
            model.EngineDisplacement = item.EngineDisplacement;
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
            Car item = new Car();
            
            item.Brand = modell.Brand;
            item.Model = modell.Model;
            item.Color = modell.Color;
            item.InteriorMaterial = modell.InteriorMaterial;
            item.InteriorColor = modell.InteriorColor;
            item.EngineDisplacement = modell.EngineDisplacement;

            context.Cars.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "NewCar");
        }
    }
}
