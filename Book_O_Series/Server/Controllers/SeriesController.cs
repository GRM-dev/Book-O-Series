using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class SeriesController : Controller
    {
        private SeriesContext _context;

        public SeriesController(SeriesContext context)
        {
            _context = context;

        }

        // GET api/series
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>(from s in _context.Series select s.ToJson());
        }

        // GET api/series/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var se = _context.Series.FirstOrDefault(s => s.Id == id);
            if (se!=null)
            {
                return new ObjectResult(se);
            }
            return NotFound();
        }

        // POST api/series
        [HttpPost]
        public IActionResult Post([FromBody]Series value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _context.Series.Add(value);
            _context.SaveChanges();

            return CreatedAtRoute("Get", new { id = value.Id }, value);
        }

        // PUT api/series/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Series value)
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var s = _context.Series.FirstOrDefault(t => t.Id == id);
            if (s == null)
            {
                return NotFound();
            }

            s.Description = value.Description;
            s.Storyline = value.Storyline;
            s.ImagePath = value.ImagePath;
            s.Rate = value.Rate;

            _context.Series.Update(s);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/series/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var s = _context.Series.First(t => t.Id == id);
            if (s == null)
            {
                return NotFound();
            }

            _context.Series.Remove(s);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
