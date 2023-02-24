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
    public class CourseTypeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CourseTypeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CourseTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseType>>> GetcourseTypes()
        {
            var courseType =await _uow.CourseTypeRepository.GetAllAsync();
            return courseType.ToList();
        }

        // GET: api/CourseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseType>> GetCourseType(int id)
        {
            var courseType = await _uow.CourseTypeRepository.GetByIDAsync(id);

            if (courseType == null)
            {
                return NotFound();
            }

            return courseType;
        }

        // PUT: api/CourseTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseType(int id, CourseType courseType)
        {
            if (id != courseType.Id)
            {
                return BadRequest();
            }

            _uow.CourseTypeRepository.Update(courseType);

            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseTypeExists(id))
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

        // POST: api/CourseTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseType>> PostCourseType(CourseType courseType)
        {
            _uow.CourseTypeRepository.Insert(courseType);
            await _uow.SaveAsync();

            return CreatedAtAction("GetCourseType", new { id = courseType.Id }, courseType);
        }

        // DELETE: api/CourseTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseType(int id)
        {
            var courseType = await _uow.CourseTypeRepository.GetByIDAsync(id);
            if (courseType == null)
            {
                return NotFound();
            }

            _uow.CourseTypeRepository.Delete(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private bool CourseTypeExists(int id)
        {
            return _uow.CourseTypeRepository.Get(e => e.Id == id).Any();
        }
    }
}
