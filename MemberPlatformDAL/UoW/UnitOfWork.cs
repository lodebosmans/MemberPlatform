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
        private GenericRepository<Address> addressRepository;
        //private GenericRepository<Relationship> relationshipRepository;
        //private GenericRepository<CourseType> courseTypeRepository;
        //private GenericRepository<PaymentStatus> paymentStatusRepository;

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

        public GenericRepository<Address> AddressRepository
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new GenericRepository<Address>(_context);
                }
                return addressRepository;
            }
        }

        //public GenericRepository<Relationship> RelationshipRepository
        //{
        //    get
        //    {
        //        if (relationshipRepository == null)
        //        {
        //            relationshipRepository = new GenericRepository<Relationship>(_context);
        //        }
        //        return relationshipRepository;
        //    }
        //}
        //public GenericRepository<CourseType> CourseTypeRepository
        //{
        //    get
        //    {
        //        if (courseTypeRepository == null)
        //        {
        //            courseTypeRepository = new GenericRepository<CourseType>(_context);
        //        }
        //        return courseTypeRepository;
        //    }
        //}
        //public GenericRepository<PaymentStatus> PaymentStatusRepository
        //{
        //    get
        //    {
        //        if (PaymentStatusRepository == null)
        //        {
        //            paymentStatusRepository = new GenericRepository<PaymentStatus>(_context);
        //        }
        //        return paymentStatusRepository;
        //    }
        //}


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
