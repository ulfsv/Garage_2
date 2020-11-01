using Garage_2.Data;
using Garage_2.Models;
using Garage_2.Models.DetailsViewModels;
using Garage_2.Models.ReceiptViewModel;
using Garage_2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        //***************************************************************** GET: ParkedVehicles *********************************************
        public async Task<IActionResult> Index(string inputSearchString = null)
        {
            bool searchHit = false;

            var model = db.ParkedVehicle
                .Include(s => s.Member)
                .Include(s => s.VehicleType)
                .Select(p => new ParkedViewModel()
                {
                    Id = p.Id,
                    VehicleTypeVehicType = p.VehicleType.VehicType,
                    RegisterNumber = p.RegisterNumber,
                    ParkedDateTime = p.ParkedDateTime,
                    MemberFullName = p.Member.FullName,
                    MemberAvatar = p.Member.Avatar,
                    MemberSocialSecurityNumber = p.Member.SocialSecurityNumber,
                    MemberEmail = p.Member.Email,
                    MemberAdress = p.Member.Adress
                    // Include(c => c.ParkedVehicles<ParkedVehicle>)
                });

            if (inputSearchString != null)
            {
                 foreach (var m in model)
                 {
                    // Searching for registration number
                    if (m.RegisterNumber == inputSearchString.ToUpper())
                    {
                        model = model.Where(p => p.RegisterNumber.Contains(inputSearchString.ToUpper()));
                        searchHit = true;
                        break;
                    }
                    // Searching for vehicle type
                    else if (m.VehicleTypeVehicType.ToLower() == inputSearchString.ToLower())
                    {
                        model = model.Where(p => p.VehicleTypeVehicType.ToLower().Contains(inputSearchString.ToLower()));
                        searchHit = true;
                        break;
                    }
                }
            }

            if (searchHit == false && inputSearchString != null)
            {
                ViewData["message"] = "Sorry, nothing found!" + "<br />" + "Showing all vehicles ";
                return View("Index2", await model.ToListAsync());
            }
            else
            {
                ViewData["message"] = "";
                return View("Index2", await model.ToListAsync());
            }
        }


        //***************************************** GET: ParkedVehicles/Details/5 *****************************************************************
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model =  db.ParkedVehicle.Include(s => s.Member).Include(s => s.VehicleType).Include(s => s.Member.ParkedVehicles)
                .Select(p => new DetailsViewModel
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

        //************************************************** GET: ParkedVehicles/Create *********************************************************************
        public IActionResult Create()
        {
            CreateDropDownLists();
            return View();
        }

        //************************************************** POST: ParkedVehicles/Create *********************************************************************
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
            (
                [Bind("Id,RegisterNumber,Color,Model,Brand,WheelsNumber,ParkedDateTime")] ParkedVehicle parkedVehicle, 
                string Members,         // From View member dropdown select
                string VehicleTypes,    // From View vehicle type dropdown select
                string newVehicleType   // From new vehicle input text field
            )
        {
            DateTime now = DateTime.Now;
            parkedVehicle.ParkedDateTime = now;
           

            bool IsProductRegNumberExist = db.ParkedVehicle.Any  // logic for reg nr
            (x => x.RegisterNumber == parkedVehicle.RegisterNumber && x.Id != parkedVehicle.Id);
            
            if (IsProductRegNumberExist == true)
            {
                ModelState.AddModelError("RegisterNumber", "RegisterNumber already exists");
            }

            int parsedMemberId = 0;

            if (Int32.TryParse(Members, out parsedMemberId))
            {
                if (parsedMemberId == 0)
                {
                    // MemberId is used in Create.cshtml @Html.ValidationMessage(
                    ModelState.AddModelError("MemberId", "No member chosen!");
                }

                parkedVehicle.MemberId = parsedMemberId;
            }

            // If user adds new vehicle type, the new vehicle type overrides the vehicle type chosen from the dropdown select
            if (String.IsNullOrWhiteSpace(newVehicleType)) // No new vehicle type given by user
            {
                int parsedVehicleType = 0;

                if (Int32.TryParse(VehicleTypes, out parsedVehicleType))
                {
                    if (parsedVehicleType == 0)
                    {
                        // VehicTyp is used in Create.cshtml @Html.ValidationMessage(
                        ModelState.AddModelError("VehicTyp", "No vehicle type chosen!");
                    }

                    parkedVehicle.VehicleTypeId = parsedVehicleType;
                }
            }
            else
            {
                bool isVehicleTypeUnique = checkIfVehicleTypeIsUnique(newVehicleType);
                
                if (isVehicleTypeUnique == false)
                {
                    ModelState.AddModelError("VehicleTypeExist", "Vehicle type already exists in database");
                }
                
                // Create new Vehicle Type                
                VehicleType newVT = new VehicleType();
                newVT.VehicType = newVehicleType;
                db.VehicleType.Add(newVT);
                await db.SaveChangesAsync();

                parkedVehicle.VehicleType = newVT;
            }

            if (ModelState.IsValid)
            {
                db.Add(parkedVehicle);
                await db.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CreateDropDownLists();
            }

            return View(parkedVehicle);
        }


        //************************************** GET: ParkedVehicles/Edit/5 ********************************************************
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

        //****************************************** POST: ParkedVehicles/Edit/5 *****************************************************
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

        //**************************************************** GET: ParkedVehicles/Delete/5 *************************************
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


        //****************************************** POST: ParkedVehicles/Delete/5 *******************************************
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

        //******************************************************** CalculateTime ****************************************
        public int CalculateTime( DateTime TimeParked)
        {
            double totalTime = 0;
          
                totalTime = (DateTime.Now - TimeParked).TotalMinutes;
                totalTime = Math.Ceiling((DateTime.Now - TimeParked).TotalMinutes)/60.0;
                int IntTotalTime = Convert.ToInt32(totalTime);

            return IntTotalTime;
        }

        //**************************************************** CalculatePrice *****************************************
        public int CalculatePrice( int totalTime, int PricePerHour)
        { 
            int totalCost =  totalTime * PricePerHour;
            return totalCost;
        }


        //******************************* CreateDropdownSelectListItemForMembers **************************************
        public List<SelectListItem> CreateDropdownSelectListItemForMembers(List<Member> membersList)
        {
            List<SelectListItem> itemsList = null;
            string selectListItemText = String.Empty; 

            if (membersList != null)
            {
                itemsList = new List<SelectListItem>();
                itemsList.Add(new SelectListItem { Text = "No member chosen", Value = "0" });

                foreach (var member in membersList)
                {
                    selectListItemText = $"{member.FullName} ({member.SocialSecurityNumber})";   
                    itemsList.Add(new SelectListItem { Text = selectListItemText, Value = member.Id.ToString() });
                }
            }
            return itemsList;
        }

        //******************************* CreateDropdownSelectListItemForVehicleTypes **************************************
        public List<SelectListItem> CreateDropdownSelectListItemForVehicleTypes(List<VehicleType> vehicleTypesList)
        {
            List<SelectListItem> itemsList = null;
            string selectListItemText = String.Empty;

            if (vehicleTypesList != null)
            {
                itemsList = new List<SelectListItem>();
                itemsList.Add(new SelectListItem { Text = "No vehicle type chosen", Value = "0" });

                foreach (var veTyp in vehicleTypesList)
                {
                    selectListItemText = $"{veTyp.VehicType}";
                    itemsList.Add(new SelectListItem { Text = selectListItemText, Value = veTyp.Id.ToString() });
                }
            }
            return itemsList;
        }

        //****************************************** checkIfVehicleTypeIsUnique ***************************
        private bool checkIfVehicleTypeIsUnique(string newVehicleType)
        {
            string newVehicleTypeToLower = newVehicleType.ToLower();

            var vehicleType = db.VehicleType.FirstOrDefault(v => v.VehicType.ToLower() == newVehicleTypeToLower);

            if (vehicleType == null)
            {
                return true;
            }

            return false;
            
        }





        public async Task<IActionResult> ViewVehicleDetails(int? id) {
        
                if (id == null)
            {
                return NotFound();
            }
             ViewBag.amount = 0;
             

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
           
               ViewBag.amount++;


            return View("VehicleDetails", model);
        }

        //************************************ CreateDropDownLists *****************************************
        private void CreateDropDownLists()
        {
            List<Member> membersList = db.Member.ToList<Member>();
            ViewBag.Members = CreateDropdownSelectListItemForMembers(membersList);
            List<VehicleType> vehicleTypesList = db.VehicleType.ToList<VehicleType>();
            ViewBag.VehicleTypes = CreateDropdownSelectListItemForVehicleTypes(vehicleTypesList);
        }
    }
}
