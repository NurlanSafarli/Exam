using ExamDoorang.DAL;
using ExamDoorang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamDoorang.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            List<Place> Places = await _context.Places.ToListAsync();
            return View(Places);
        }

      
    }
}