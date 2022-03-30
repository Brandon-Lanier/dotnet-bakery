using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context) {
            _context = context; // This is essentially our pool
        }

        // OUR API
        // Get all bakers
        [HttpGet] // This tells it that its a Get route
        public IEnumerable<Baker> GetAll() { // Getall is taco
            Console.WriteLine("get all bakers");
            //no SQL!  returns all the rows in the bakers table
            return _context.Bakers;
        }


        // Get 1 baker {id}
        // GET method api/bakers/:id
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id) 
        {
            Baker baker = _context.Bakers.SingleOrDefault(baker => baker.id == id);
            if (baker is null) {
                return NotFound();  // res.sendStatus(404)
            }
            return baker;
        }

        // Post - add a new baker
        [HttpPost]
        public IActionResult Post(Baker baker)
        {
            _context.Add(baker);
            _context.SaveChanges(); // This commits the changes to the database

            // return baker; // This would be missing the ID

            // returns the url to /api/Bakers?id=<new-id-number>
            return CreatedAtAction(nameof(Post), new { id = baker.id}, baker);
        }
        // Delete - Delete a baker by {id}
        // PUt - change a bakers name by id

    }
}
