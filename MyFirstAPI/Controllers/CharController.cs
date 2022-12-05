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
            Response responseObject = new Response();
            responseObject.statusCode = 200;
            responseObject.statusDescription = "Character list";
            return Ok(await _context.Characters.ToListAsync());
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            Response responseObject = new Response();
            var characterList = await _context.Characters.FindAsync(id);
            if (characterList == null)
            {
                responseObject.statusCode = 400;
                responseObject.statusDescription = "Invalid character ID";
                return Ok(responseObject);
            }

            return characterList;
        }

        // GET: api/House
        [HttpGet("/api/house")]
        public async Task<ActionResult<IEnumerable<House>>> GetHouse()
        {
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
            Response responseObject = new Response();
            var findChar = await _context.Characters.FindAsync(character.CharacterID);

            if (findChar != null)
            {
                responseObject.statusCode = 400;
                responseObject.statusDescription = "Character cannot be created, existing ID.";

                return Ok(responseObject);
            }

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            responseObject.statusCode = 200;
            responseObject.statusDescription = "Character added created";
            return Ok(responseObject);
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteCharacter(int id)
        {
            Response responseObject = new Response();

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                responseObject.statusCode = 400;
                responseObject.statusDescription = "Invalid character ID";
                return responseObject;
            }

            _context.Characters.Remove(character);  
            await _context.SaveChangesAsync();
            responseObject.statusCode = 200;
            responseObject.statusDescription = "Character deleted";

            return responseObject;
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.CharacterID == id)).GetValueOrDefault();
        }
    }
}


