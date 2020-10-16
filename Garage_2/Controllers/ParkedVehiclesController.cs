using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2.Data;
using Garage_2.Models;
using Garage_2.Models.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using System.Windows;
using Garage_2.Models.ReceiptViewModel;

namespace Garage_2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage_2Context db;

        public ParkedVehiclesController(Garage_2Context context)
        {
            db = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            var model = db.ParkedVehicle.Select(p => new ParkedViewModel() { Id = p.Id, VehicleType = p.VehicleType, RegisterNumber = p.RegisterNumber, ParkedDateTime = p.ParkedDateTime }
        );
            return View("Index2", await model.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleType,RegisterNumber,Color,Model,Brand,WheelsNumber,ParkedDateTime")] ParkedVehicle parkedVehicle)
        {
           
            bool IsProductRegNumberExist = db.ParkedVehicle.Any  // logic for reg nr
            (x => x.RegisterNumber == parkedVehicle.RegisterNumber && x.Id != parkedVehicle.Id);
            if (IsProductRegNumberExist == true)
            {
                ModelState.AddModelError("RegisterNumber", "RegisterNumber already exists");
            }






            if (ModelState.IsValid)
            {
                db.Add(parkedVehicle);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleType,RegisterNumber,Color,Model,Brand,WheelsNumber,ParkedDateTime,CheckOutDateTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(parkedVehicle);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkedVehicle = await db.ParkedVehicle.FindAsync(id);
            db.ParkedVehicle.Remove(parkedVehicle);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
            return db.ParkedVehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Receipt(int? id)
        {
            Receipt receipt = null;

            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            else
            {
                receipt = new Receipt();
                receipt.ParkingTime = parkedVehicle.ParkedDateTime;
                receipt.RegNr = parkedVehicle.RegisterNumber;
                receipt.PricePerHour = 100;// TODO Do somewhere else
                receipt.TotalTimeParked = CalculateTime(parkedVehicle.ParkedDateTime);
                receipt.Cost = CalculatePrice(receipt.TotalTimeParked, receipt.PricePerHour);
                

                //receipt.Cost = CalculatePrice(CalculatePrice(CalculateTime(parkedVehicle.ParkedDateTime),receipt.PricePerHour)) ;
            }

            return View(receipt);
        }
    
        public int CalculateTime( DateTime TimeParked)
        {
            int totalTime = (((DateTime.Now.Day-TimeParked.Day)*24)+ DateTime.Now.Hour - TimeParked.Hour);
            return totalTime;
           
        }

        
        public int CalculatePrice( int totalTime, int PricePerHour)
        { 
            int totalCost =  totalTime * PricePerHour;
            return totalCost;
            
        }

    }
}
