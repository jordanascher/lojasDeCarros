using LojaDeCarros.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaDeCarros.Models;

namespace LojaDeCarros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly AppDbContext _context;

        public CarrosController (AppDbContext context)
        {
            _context = context;
        }

        // GET: HomeController1
        public async Task<ActionResult> Index()
        {
            var carros = await _context.Carros.ToListAsync();
            return View(carros);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Carros.Add(carro);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,AnoModelo,Chassi,Preco")] Carro carro)
        {
            if (id != carro.Id) {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return View(carro);
            }

            try
            {
                _context.Update(carro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(carro.Id))
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
        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = _context.Carros.Find(id);

            _context.Carros.Remove(carro);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
