using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabajoPractico3.Context;
using TrabajoPractico3.Models;

namespace TrabajoPractico3.Controllers
{
    public class PersonasInformacionController : Controller
    {
        private readonly TrabajoPractico3Context _context;

        public PersonasInformacionController(TrabajoPractico3Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("MasInfo", "PersonasInformacion");
        }

        public IActionResult ConsultarInfo()
        {
            return View();
        }

        public IActionResult TraerInfo()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TraerInfo(int id)
        {
            if (_context.PersonasInformacion == null)
            {
                return NotFound();
            }

            var persona = await _context.PersonasInformacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: PersonasInformacion/MasInfo
        public IActionResult MasInfo()
        {
            return View();
        }

        // POST: PersonasInformacion/MasInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MasInfo(PersonasInformacion personasInformacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personasInformacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personasInformacion);
        }
    }
}
