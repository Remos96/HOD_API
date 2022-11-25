using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly MyFirstAPIDBContext _context;

        public CharacterController(MyFirstAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Character
        [HttpGet("/api/character")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            //if (_context.Characters == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Characters.ToListAsync();
            return Ok(await _context.Characters.ToListAsync());
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // GET: api/House
        [HttpGet("/api/house")]
        public async Task<ActionResult<IEnumerable<House>>> GetHouse()
        {
            //if (_context.Houses == null)
            //{
            //    return NotFound();
            //}
            return Ok(await _context.House.ToListAsync());
        }

        // PUT: api/Character/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Character character)
        {
            if (id != character.CharacterID)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Character
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/character")] //post
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            if (_context.Characters == null)
            {
                return Problem("Entity set 'MyFirstAPIDBContext.Characters'  is null.");
            }
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCharacter", new { id = character.CharacterID }, character);
            return Ok(await _context.Characters.ToListAsync());
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.CharacterID == id)).GetValueOrDefault();
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MyFirstAPI.Models;

//namespace MyFirstAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly MyFirstAPIDBContext _context;

//        public CustomerController(MyFirstAPIDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Customer
//        [HttpGet("/api/customer")]
//        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
//        {
//          if (_context.Customers == null)
//          {
//              return NotFound();
//          }
//            return await _context.Customers.ToListAsync();
//        }

//        // GET: api/Customer/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Customer>> GetCustomer(int id)
//        {
//          if (_context.Customers == null)
//          {
//              return NotFound();
//          }
//            var customer = await _context.Customers.FindAsync(id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return customer;
//        }

//        // PUT: api/Customer/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCustomer(int id, Customer customer)
//        {
//            if (id != customer.CustomerID)
//            {
//                return BadRequest();
//            }

//            _context.Entry(customer).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CustomerExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Customer
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost("/api/customer")]
//        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
//        {
//          if (_context.Customers == null)
//          {
//              return Problem("Entity set 'MyFirstAPIDBContext.Customers'  is null.");
//          }
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
//        }

//        // DELETE: api/Customer/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCustomer(int id)
//        {
//            //from customers, grab email from customer, and only take the customer that matches == id
//            var customer = await _context.Customers.Include(c => c.Email).FirstOrDefaultAsync(c => c.CustomerID == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            _context.Customers.Remove(customer);

//            var email = await _context.Emails.FirstOrDefaultAsync(e => e.EmailId == customer.Email.EmailId);

//            _context.Emails.Remove(email);

//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool CustomerExists(int id)
//        {
//            return (_context.Customers?.Any(e => e.CustomerID == id)).GetValueOrDefault();
//        }
//    }
//}
