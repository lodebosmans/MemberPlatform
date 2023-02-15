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

        // GET: api/RelationShips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relationship>>> GetRelationships()
        {
            var relationShips = await _uow.RelationShipRepository.GetAllAsync();
            return relationShips.ToList();
        }
    

        // GET: api/RelationShips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relationship>> GetRelationShip(int id)
        {
            var relationShip = await _uow.RelationShipRepository.GetByIDAsync(id);

        if (relationShip == null)
            {
                return NotFound();
            }

            return relationShip;
        }

        // PUT: api/RelationShips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationShip(int id, Relationship relationShip)
        {
            if (id != relationShip.Id)
            {
                return BadRequest();
            }

            _uow.RelationShipRepository.Update(relationShip);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationShipExists(id))
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

        // POST: api/RelationShips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Relationship>> PostRelationShip(Relationship relationShip)
        {
            _uow.RelationShipRepository.Insert(relationShip);
            await _uow.SaveAsync();
            return CreatedAtAction("GetRelationShip", new { id = relationShip.Id }, relationShip);
        }

        // DELETE: api/RelationShips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationShip(int id)
        {
            var relationShip = await _uow.RelationShipRepository.GetByIDAsync(id);
            if (relationShip == null)
            {
                return NotFound();
            }

            _uow.RelationShipRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool RelationShipExists(int id)
        {
            return _uow.RelationShipRepository.Get(e => e.Id == id).Any();
        }
    }
}
