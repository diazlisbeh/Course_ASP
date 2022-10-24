using ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    public class SchoolController : Controller
    {
        private SchoolContext _context;

        public SchoolController(SchoolContext contesxt){
            _context = contesxt;
        }
        public IActionResult Index(){
            return View(_context.Schools.First());
        }
        [Route("School/Index/{id}")]
        public IActionResult Index( int id){
            var s = from a in _context.Schools
                     where a.Id == id
                     select a;
            
            return View(s.SingleOrDefault());
        }
        
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public IActionResult Create(School school){
           if(ModelState.IsValid){
            _context.Schools.Add(school);
            _context.SaveChanges();
            ViewBag.Exito = "Curso Creado";
            return View("Index", school);
           }else{
           return View(school);
           }
        }

        public IActionResult AllSchools(){
            var s = _context.Schools.ToList();

            return View(s);
        }

    }
}