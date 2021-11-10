using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly MyDBContext _context;

        public PersonController(ILogger<PersonController> logger,MyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var people = _context.Person.ToArray();
            return people;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {

            var person = _context.Person.FirstOrDefault(x=> x.Id==id);
            return person;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person person)
        {
            var person_found = _context.Person.FirstOrDefault(e => e.Id == id);
            person_found.FirstName = person.FirstName;
            person_found.LastName = person.LastName;
            person_found.Age = person.Age;
            person_found.IsPlayer = person.IsPlayer;

            _context.SaveChanges();

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Remove(_context.Person.FirstOrDefault(e => e.Id == id));
            _context.SaveChanges();
        }
    }
}
