using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VroomAppTwo.AppDbContext;
using VroomAppTwo.Models;

namespace VroomAppTwo.Controllers
{
    public class MakeController : Controller
    {
        private readonly VroomDbContext _vroomDbContext;
        public MakeController(VroomDbContext vroomDbContext)
        {
            _vroomDbContext = vroomDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vroomDbContext.Makes.ToListAsync());
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>  Create(Make make)
        {
            if (ModelState.IsValid)
            {
                await _vroomDbContext.Makes.AddAsync(make);
               await _vroomDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        [HttpPost]//never us http get for any data modification action also post is not all together secure
        public async Task <IActionResult> Delete(int Id)
        {
            Make make = await _vroomDbContext.Makes.FindAsync(Id);
            if (make == null)
            {
                return NotFound();
            }  ;
            _vroomDbContext.Makes.Remove(make);
            await _vroomDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Make make = _vroomDbContext.Makes.Find(Id);
            if(make == null)
            {
                return NotFound();
            }
            return View(make);
        }
        [HttpPost]
        public IActionResult Edit(Make make)
        {
            _vroomDbContext.Makes.Update(make);
            if (ModelState.IsValid)
            {
                _vroomDbContext.Makes.Update(make);
                _vroomDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
        //make/bikes
        //[Route("Make")]
        //[Route("Make/Bikes")]
        public IActionResult Bikes()
        {
            Make newMake = new Make { Id = 2, Name = "abayomi" };
            return View(newMake);
            //return Redirect("/home");

            //return RedirectToAction("Privacy", "Home"); 

            
        }
    }
}
