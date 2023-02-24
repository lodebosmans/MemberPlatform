using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemberPlatformDAL.Data;
using MemberPlatformDAL.Models;
using MemberPlatformDAL.UoW;

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RelationshipController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Relationships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relationship>>> GetRelationships()
        {
            var relationships = await _uow.RelationshipRepository.GetAllAsync();
            return relationships.ToList();
        }
    

        // GET: api/Relationships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relationship>> GetRelationship(int id)
        {
            var relationship = await _uow.RelationshipRepository.GetByIDAsync(id);

        if (relationship == null)
            {
                return NotFound();
            }

            return relationship;
        }

        // PUT: api/Relationships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationship(int id, Relationship relationship)
        {
            if (id != relationship.Id)
            {
                return BadRequest();
            }

            _uow.RelationshipRepository.Update(relationship);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationshipExists(id))
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

        // POST: api/Relationships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Relationship>> PostRelationship(Relationship relationship)
        {
            _uow.RelationshipRepository.Insert(relationship);
            await _uow.SaveAsync();
            return CreatedAtAction("GetRelationship", new { id = relationship.Id }, relationship);
        }

        // DELETE: api/Relationships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationship(int id)
        {
            var relationship = await _uow.RelationshipRepository.GetByIDAsync(id);
            if (relationship == null)
            {
                return NotFound();
            }

            _uow.RelationshipRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool RelationshipExists(int id)
        {
            return _uow.RelationshipRepository.Get(e => e.Id == id).Any();
        }
    }
}
