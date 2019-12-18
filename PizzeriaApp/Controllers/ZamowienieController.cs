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
    public class ZamowienieController : ControllerBase
    {

        private s16728Context _context;

        public ZamowienieController(s16728Context context)
        {
            _context = context;
        }
        //api/zamowienie
        [HttpGet]
        public IActionResult GetZamowienie()
        {
            return Ok(_context.Zamowienie.ToList());
        }
        //api/zamowienie/1
        [HttpGet("{id:int}")]
        public IActionResult GetZamowienie(int id)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }

    }
}