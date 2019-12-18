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
    public class PizzaController : ControllerBase
    {
        private s16728Context _context;

        public PizzaController(s16728Context context)
        {
            _context = context;
        }
        /// <summary>
        /// Endpoint for getting values
        /// </summary>
        /// <returns>fasdfsadfsdafsdaf</returns>
        //api/pizza
        [HttpGet]
        public IActionResult GetPizza()
        {
            return Ok(_context.Pizza.ToList());
        }
        //api/pizza/1
        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if(pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }
        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza); //201, 202

        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Pizza updatedPizza)
        {
           // var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == updatedPizza.IdPizza);

            if(_context.Pizza.Count(e => e.IdPizza == id) == 0) //  ----- zamiast ^^^
            //if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);

        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if(pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

    }
}