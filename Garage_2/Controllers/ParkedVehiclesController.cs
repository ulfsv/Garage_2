﻿using Garage_2.Data;
using Garage_2.Models;
using Garage_2.Models.DetailsViewModels;
using Garage_2.Models.ReceiptViewModel;
using Garage_2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


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
        public async Task<IActionResult> Index(string inputRegNumber = null)
        {
            var model = db.ParkedVehicle.Include(s =>s.Member).Include(s => s.VehicleType)
                .Select(p => new ParkedViewModel() { Id = p.Id,
                    VehicleTypeVehicType = p.VehicleType.VehicType, RegisterNumber = p.RegisterNumber, ParkedDateTime = p.ParkedDateTime,
                    MemberFullName = p.Member.FullName, MemberAvatar = p.Member.Avatar,
                    MemberSocialSecurityNumber = p.Member.SocialSecurityNumber,
                    MemberEmail = p.Member.Email,
                    MemberAdress = p.Member.Adress,
                   // Include(c => c.ParkedVehicles<ParkedVehicle>)

                }
                
                );

            if (inputRegNumber != null) // sökFunction
            {
                model = model.Where(p => p.RegisterNumber.Contains(inputRegNumber)  ); 
                //SÖK BÅDA vehicle type  OCH reg NUMBER
            }
            return View("Index2", await model.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*  var parkedVehicle = await db.ParkedVehicle
                  .FirstOrDefaultAsync(m => m.Id == id);*/

            var model =  db.ParkedVehicle.Include(s => s.Member).Include(s => s.VehicleType).Include(s => s.Member.ParkedVehicles)
                .Select(p => new DetailsViewModel()
                {
                    Id = p.Id,
                    VehicleTypeVehicType = p.VehicleType.VehicType,
                    RegisterNumber = p.RegisterNumber,
                    ParkedDateTime = p.ParkedDateTime,
                    MemberFullName = p.Member.FullName,
                    Color=p.Color,
                    Model=p.Model,
                    Brand =p.Brand,
                    WheelsNumber=p.WheelsNumber,
                    MemberAvatar = p.Member.Avatar,
                    // MemberSocialSecurityNumber = p.Member.SocialSecurityNumber,
                    MemberEmail = p.Member.Email,
                    MemberAdress = p.Member.Adress,
                    ParkedVehicles = p.Member.ParkedVehicles
                }).FirstOrDefault(s => s.Id == id);





            if (model == null)
            {
                return NotFound();
            }

            return View(  model);
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
            DateTime now = DateTime.Now;
            parkedVehicle.ParkedDateTime = now;
           

            bool IsProductRegNumberExist = db.ParkedVehicle.Any  // logic for reg nr
            (x => x.RegisterNumber == parkedVehicle.RegisterNumber && x.Id != parkedVehicle.Id);
            if (IsProductRegNumberExist == true)
            {
                ModelState.AddModelError("RegisterNumber", "RegisterNumber already exists");
            }

            if (ModelState.IsValid)
            {
                db.Add(parkedVehicle);
                db.VehicleType.Add(parkedVehicle.VehicleType);   /// to save data base to table VehicleType
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
        //
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleType,RegisterNumber,Color,Model,Brand,WheelsNumber,ParkedDateTime")] ParkedVehicle parkedVehicle)
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

            var parkedVehicle = await db.ParkedVehicle.FirstOrDefaultAsync(m => m.Id == id);

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

            var parkedVehicle = await db.ParkedVehicle.FirstOrDefaultAsync(m => m.Id == id);

            if (parkedVehicle == null)
            {
                return NotFound();
            }
            else
            {
                receipt = new Receipt();
                receipt.ParkingTime = parkedVehicle.ParkedDateTime;
                receipt.RegNr = parkedVehicle.RegisterNumber;
                receipt.PricePerHour = 100;
                receipt.TotalTimeParked = CalculateTime(parkedVehicle.ParkedDateTime);
                receipt.Cost = CalculatePrice(receipt.TotalTimeParked, receipt.PricePerHour);
            }

            await DeleteConfirmed((int)id);
            return View(receipt);
        }
    
        public int CalculateTime( DateTime TimeParked)
        {
            int minsFromDays = (DateTime.Now.Day - TimeParked.Day) * 24 * 60;
            int minsFromhours = (DateTime.Now.Hour - TimeParked.Hour) * 60;
            int mins = DateTime.Now.Minute - TimeParked.Minute;
            int totalTime = (int)Math.Ceiling((minsFromDays + minsFromhours + mins) / 60.0);
            return totalTime;
        }

        
        public int CalculatePrice( int totalTime, int PricePerHour)
        { 
            int totalCost =  totalTime * PricePerHour;
            return totalCost;
            
        }





        public async Task<IActionResult> ViewVehicleDetails(int? id) {
        
                if (id == null)
            {
                return NotFound();
            }


            var model = await db.ParkedVehicle.Select(p => new VehicleDetals
            {
                Id = p.Id,
                VehicleType = p.VehicleType.VehicType,
                Brand = p.Brand,
                Color = p.Color,
                Model = p.Model,
                ParkedDateTime = p.ParkedDateTime,
                RegisterNumber = p.RegisterNumber,
                WheelsNumber = p.WheelsNumber
            }).FirstOrDefaultAsync(m => m.Id ==id);
           
              


            return View("VehicleDetails", model);
        }










}
}
