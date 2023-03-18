using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductUnitController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ProductUnitController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/ProductUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductUnitEntity>>> GetProductUnits()
        {
            var productunits = await _uow.ProductUnitRepository.GetAllAsync();
            return productunits.ToList();
        }

        // GET api/ProductUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductUnitEntity>> GetProductUnit(int id)
        {
            var productUnit = await _uow.ProductUnitRepository.GetByIDAsync(id);

            if (productUnit == null)
            {
                return NotFound();
            }

            return productUnit;
        }

        // POST api/ProductUnit
        [HttpPost]
        public async Task<ActionResult<ProductUnitEntity>> PostProductUnit(ProductUnitEntity productUnit)
        {
            _uow.ProductUnitRepository.Insert(productUnit);
            await _uow.SaveAsync();

            return CreatedAtAction("GetProductUnit", new { id = productUnit.Id }, productUnit);
        }

        // PUT api/Address/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductUnit(int id, ProductUnitEntity productUnit)
        {

            if (id != productUnit.Id)
            {
                return BadRequest();
            }

            _uow.ProductUnitRepository.Update(productUnit);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductUnitExists(id))
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

        private bool ProductUnitExists(int id)
        {
            return _uow.ProductUnitRepository.Get(e => e.Id == id).Any();
        }


        // DELETE api/Address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductUnit(int id)
        {
            var productUnit = await _uow.ProductUnitRepository.GetByIDAsync(id);
            if (productUnit == null)
            {
                return NotFound();
            }

            _uow.AddressRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }
    }
}
