using CRUDNet8MVC.Data;
using CRUDNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUDNet8MVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly AplicationDBContext _context;
        public HomeController(AplicationDBContext context)
        {
            _context = context;
            ///_logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelContact.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {

            }
            var contact = _context.ModelContact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {

            }
            var contact = _context.ModelContact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {

            }
            var contact = _context.ModelContact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreationDate = DateTime.Now;
                _context.ModelContact.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContact(int? id)
        {
            var contact = await _context.ModelContact.FindAsync(id);
            if(contact == null)
            {
                return View("Error");
            }
            _context.ModelContact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
