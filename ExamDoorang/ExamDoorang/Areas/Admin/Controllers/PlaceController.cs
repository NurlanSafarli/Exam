using ExamDoorang.Areas.Admin.ViewModels;
using ExamDoorang.DAL;
using ExamDoorang.Models;
using ExamDoorang.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace ExamDoorang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlaceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PlaceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Place> Places = await _context.Places.ToListAsync();
            return View(Places);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaceVm PlaceVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!PlaceVM.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect");
                return View();
            }
            if (!PlaceVM.Photo.CheckSize(200))
            {
                ModelState.AddModelError("Photo", "File size is incorrect");
                return View();
            }
            string filename = Guid.NewGuid().ToString() + PlaceVM.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets", "imgs", filename);
            FileStream file = new FileStream(path, FileMode.Create);
            await PlaceVM.Photo.CopyToAsync(file);
            Place Place = new Place
            {
                Title= PlaceVM.Title,
                Subtitle= PlaceVM.Subtitle,
                Description= PlaceVM.Description,
                PhotoUrl=filename
                
            };
            await _context.Places.AddAsync(Place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Place Place = await _context.Places.FirstOrDefaultAsync(x => x.Id == id);
            if (Place == null)
            {
                return NotFound();
            }
            UpdatePlaceVM PlaceVM = new UpdatePlaceVM
            {
                Title= Place.Title,
                Subtitle= Place.Subtitle,
                Description= Place.Description,
                PhotoUrl= Place.PhotoUrl,


            };
            return View(PlaceVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdatePlaceVM PlaceVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Place existed = await _context.Places.FirstOrDefaultAsync(c => c.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
            if (PlaceVM.Photo is not null)
            {
                if (!PlaceVM.Photo.CheckType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type is incorrect");
                    return View();
                }
                if (!PlaceVM.Photo.CheckSize(200))
                {
                    ModelState.AddModelError("Photo", "File size is incorrect");
                    return View();
                }
                string filename = Guid.NewGuid().ToString() + PlaceVM.Photo.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "imgs", filename);
                FileStream file = new FileStream(path, FileMode.Create);
                await PlaceVM.Photo.CopyToAsync(file);
                existed.PhotoUrl = filename;
                existed.PhotoUrl.DeleteFile(_env.WebRootPath, "assets", "imgs");
            }
            existed.Title = PlaceVM.Title;
            existed.Subtitle = PlaceVM.Subtitle;
            existed.Description = PlaceVM.Description;
            

            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof (Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Place existed = await _context.Places.FirstOrDefaultAsync(x => x.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
            existed.PhotoUrl.DeleteFile(_env.WebRootPath, "assets", "uploads");
            _context.Places.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

    }
}
