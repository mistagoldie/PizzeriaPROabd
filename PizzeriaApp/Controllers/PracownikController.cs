using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Models;

namespace PizzeriaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracownikController : ControllerBase
    {

        private s16728Context _context;

        public PracownikController(s16728Context context)
        {
            _context = context;
        }
        //api/pracownik
        [HttpGet]
        public IActionResult GetPracownik()
        {
            return Ok(_context.Pracownik.ToList());
        }
        //api/pizza/1
        [HttpGet("{id:int}")]
        public IActionResult GetPracownik(int id)
        {
            var pracownik = _context.Pracownik.FirstOrDefault(e => e.IdPracownik == id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return Ok(pracownik);
        }

    }
}