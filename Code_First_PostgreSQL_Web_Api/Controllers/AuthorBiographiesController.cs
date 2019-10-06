using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Code_First_PostgreSQL_Web_Api.Dal;
using Code_First_PostgreSQL_Web_Api.Models;

namespace Code_First_PostgreSQL_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBiographiesController : ControllerBase
    {
        private readonly BookDbContext _context;

        public AuthorBiographiesController(BookDbContext context)
        {
            _context = context;
        }

        // GET: api/AuthorBiographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBiography>>> GetAuthorBiographies()
        {
            return await _context.AuthorBiographies.ToListAsync();
        }

        // GET: api/AuthorBiographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBiography>> GetAuthorBiography(int id)
        {
            var authorBiography = await _context.AuthorBiographies.FindAsync(id);

            if (authorBiography == null)
            {
                return NotFound();
            }

            return authorBiography;
        }

        // PUT: api/AuthorBiographies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorBiography(int id, AuthorBiography authorBiography)
        {
            if (id != authorBiography.AuthorBiographyId)
            {
                return BadRequest();
            }

            _context.Entry(authorBiography).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorBiographyExists(id))
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

        // POST: api/AuthorBiographies
        [HttpPost]
        public async Task<ActionResult<AuthorBiography>> PostAuthorBiography(AuthorBiography authorBiography)
        {
            _context.AuthorBiographies.Add(authorBiography);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorBiography", new { id = authorBiography.AuthorBiographyId }, authorBiography);
        }

        // DELETE: api/AuthorBiographies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorBiography>> DeleteAuthorBiography(int id)
        {
            var authorBiography = await _context.AuthorBiographies.FindAsync(id);
            if (authorBiography == null)
            {
                return NotFound();
            }

            _context.AuthorBiographies.Remove(authorBiography);
            await _context.SaveChangesAsync();

            return authorBiography;
        }

        private bool AuthorBiographyExists(int id)
        {
            return _context.AuthorBiographies.Any(e => e.AuthorBiographyId == id);
        }
    }
}
