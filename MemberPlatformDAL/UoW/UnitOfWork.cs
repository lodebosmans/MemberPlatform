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
        private GenericRepository<Option> optionRepository;
        private GenericRepository<OptionType> optionTypeRepository;
        private GenericRepository<ProductDefinition> productDefinitionRepository;
        private GenericRepository<ProductUnit> productUnitRepository;
        private GenericRepository<Contract> contractRepository;
        private GenericRepository<ContractPersonInvolvement> contractPersonInvolvementRepository;
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

        public GenericRepository<Option> OptionRepository

        {
            get
            {
                if(optionRepository == null)
                {
                    optionRepository = new GenericRepository<Option>(_context);
                }
                return optionRepository;
            }
        }

        public GenericRepository<OptionType> OptionTypeRepository
        {
            get
            {
                if(optionTypeRepository == null)
                {
                    optionTypeRepository = new GenericRepository<OptionType>(_context);
                }
                return optionTypeRepository;
            }
        }

        public GenericRepository<ProductDefinition> ProductDefinitionRepository
        {
            get
            {
                if(productDefinitionRepository == null)
                {
                    productDefinitionRepository = new GenericRepository<ProductDefinition>(_context);
                }
                return productDefinitionRepository;
            }
        }
        public GenericRepository<ProductUnit> ProductUnitRepository
        {
            get
            {
                if(productUnitRepository==null)
                {
                    productUnitRepository = new GenericRepository<ProductUnit>(_context);
                }
                return productUnitRepository;
            }
        }

        public GenericRepository<ContractPersonInvolvement> ContractPersonInvolvementRepository
        {
            get
            {
                if(contractPersonInvolvementRepository==null)
                {
                    contractPersonInvolvementRepository = new GenericRepository<ContractPersonInvolvement>(_context);
                }
                return contractPersonInvolvementRepository;
            }
        }
        public GenericRepository<Contract> ContractRepository
        {
            get
            {
                if(contractRepository==null)
                {
                    contractRepository = new GenericRepository<Contract>(_context); 
                }
                return contractRepository;
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
