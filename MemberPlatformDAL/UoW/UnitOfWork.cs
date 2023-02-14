using MemberPlatformDAL.Data;
using MemberPlatformDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private GenericRepository<Person> personRepository;
        private GenericRepository<RelationShip> relationShipRepository;
        private GenericRepository<CourseType> courseTypeRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public GenericRepository<Person> PersonRepository
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new GenericRepository<Person>(_context);
                }
                return personRepository;
            }
        }
        public GenericRepository<RelationShip> RelationShipRepository
        {
            get
            {
                if (relationShipRepository == null)
                {
                    relationShipRepository = new GenericRepository<RelationShip>(_context);
                }
                return relationShipRepository;
            }
        }
        public GenericRepository<CourseType> CourseTypeRepository
        {
            get
            {
                if (courseTypeRepository == null)
                {
                    courseTypeRepository = new GenericRepository<CourseType>(_context);
                }
                return courseTypeRepository;
            }
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
