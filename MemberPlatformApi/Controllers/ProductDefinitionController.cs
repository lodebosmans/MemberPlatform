using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDefinitionController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ProductDefinitionController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/<ProductDefinitionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDefinitionEntity>>> GetProductDefinitions()
        {
            var productDefinitions = await _uow.ProductDefinitionRepository.GetAllAsync();
            return productDefinitions.ToList();
        }

        // GET api/ProductDefinition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDefinitionEntity>> GetProductDefinition(int id)
        {
            var ProductDefinition = await _uow.ProductDefinitionRepository.GetByIdAsync(id);

            if (ProductDefinition == null)
            {
                return NotFound();
            }

            return ProductDefinition;
        }

        // POST api/ProductDefinition
        [HttpPost]
        public async Task<ActionResult<ProductDefinitionEntity>> PostAddress(ProductDefinitionEntity productDefinition)
        {
            _uow.ProductDefinitionRepository.Insert(productDefinition);
            await _uow.SaveAsync();

            return CreatedAtAction("GetProductDefinition", new { id = productDefinition.Id }, productDefinition);
        }

        // PUT api/ProductDefinition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDefinition(int id, ProductDefinitionEntity productDefinition)
        {
            if (id != productDefinition.Id)
            {
                return BadRequest();
            }

            _uow.ProductDefinitionRepository.Update(productDefinition);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDefinitionExists(id))
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

        private bool ProductDefinitionExists(int id)
        {
            return _uow.ProductDefinitionRepository.Get(e => e.Id == id).Any();
        }

        // DELETE api/ProductDefinition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDefinition(int id)
        {
            var productDefinition = await _uow.ProductDefinitionRepository.GetByIdAsync(id);
            if (productDefinition == null)
            {
                return NotFound();
            }

            _uow.ProductDefinitionRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }
    }
}
