using System;
using System.Collections.Generic;
using System.Linq;
using Garage_2.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2.Data;
using Garage_2.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Garage_2.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage_2Context db;

        public MembersController(Garage_2Context context)
        {
            db = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(string inputSSN = null)

        {
            var model = db.Member.Include(s => s.ParkedVehicles).Select(p => new MemberViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FullName = $"{p.FirstName}  {p.LastName}",
                Avatar = p.Avatar,
                ParkedVehicles = p.ParkedVehicles,
                SocialSecurityNumber = p.SocialSecurityNumber,
                Email = p.Email,
                Phone = p.Phone,
                Street = p.Street

            });
            if (inputSSN != null) // sökFunction
            {
                model = model.Where(p => p.SocialSecurityNumber.Contains(inputSSN));
                //SÖK MEMBER BY SocialSecurityNumber
            }




            return View("Index2", await model.ToListAsync());
        }

      





















        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await db.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Phone,SocialSecurityNumber,Email,Street,ZIP,Avatar")] Member member)
        {
            if (member.Avatar == null) member.Avatar = "https://secure.gravatar.com/avatar/831eb2fb911095cd15676650e5aed871?s=128&d=mm&r=g";
            if (ModelState.IsValid)
            {
                db.Add(member);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await db.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,SocialSecurityNumber,Email,Street,ZIP,Avatar")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(member);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await db.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await db.Member.FindAsync(id);
            db.Member.Remove(member);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return db.Member.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ParkedViclesCount(int? id) {

            var model = await db.ParkedVehicle.Select(p => new ParkedVehicle { Id = p.Id, MemberId = p.MemberId }).ToListAsync();//.FirstOrDefaultAsync(m => m.Id == id);
            int c = 0;
            foreach (var pv in model) {
                if (id == pv.MemberId)
                    ViewBag.C ++;
}
                

            //var model = await db.ParkedVehicle.Include(s => s.Member).Select(p => new ParkedVehicle
            //{
            //    Id = p.Id,
            //     MemberId = p.MemberId
            //}).ToListAsync();
            

            return View(model);

    }
    }
}
