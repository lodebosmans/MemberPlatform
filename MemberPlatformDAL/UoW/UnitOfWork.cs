using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;

namespace MemberPlatformDAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        private GenericRepository<AddressEntity> addressRepository;
        private GenericRepository<OptionEntity> optionRepository;
        private GenericRepository<OptionTypeEntity> optionTypeRepository;
        private GenericRepository<ProductDefinitionEntity> productDefinitionRepository;
        private GenericRepository<ProductUnitEntity> productUnitRepository;
        private GenericRepository<ContractEntity> contractRepository;
        private GenericRepository<ContractPersonInvolvementEntity> contractPersonInvolvementRepository;
        //private GenericRepository<Relationship> relationshipRepository;
        //private GenericRepository<CourseType> courseTypeRepository;
        //private GenericRepository<PaymentStatus> paymentStatusRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public GenericRepository<AddressEntity> AddressRepository
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new GenericRepository<AddressEntity>(_context);
                }
                return addressRepository;
            }
        }

        public GenericRepository<OptionEntity> OptionRepository

        {
            get
            {
                if (optionRepository == null)
                {
                    optionRepository = new GenericRepository<OptionEntity>(_context);
                }
                return optionRepository;
            }
        }

        public GenericRepository<OptionTypeEntity> OptionTypeRepository
        {
            get
            {
                if (optionTypeRepository == null)
                {
                    optionTypeRepository = new GenericRepository<OptionTypeEntity>(_context);
                }
                return optionTypeRepository;
            }
        }

        public GenericRepository<ProductDefinitionEntity> ProductDefinitionRepository
        {
            get
            {
                if (productDefinitionRepository == null)
                {
                    productDefinitionRepository = new GenericRepository<ProductDefinitionEntity>(_context);
                }
                return productDefinitionRepository;
            }
        }

        public GenericRepository<ProductUnitEntity> ProductUnitRepository
        {
            get
            {
                if (productUnitRepository == null)
                {
                    productUnitRepository = new GenericRepository<ProductUnitEntity>(_context);
                }
                return productUnitRepository;
            }
        }

        public GenericRepository<ContractPersonInvolvementEntity> ContractPersonInvolvementRepository
        {
            get
            {
                if (contractPersonInvolvementRepository == null)
                {
                    contractPersonInvolvementRepository = new GenericRepository<ContractPersonInvolvementEntity>(_context);
                }
                return contractPersonInvolvementRepository;
            }
        }

        public GenericRepository<ContractEntity> ContractRepository
        {
            get
            {
                if (contractRepository == null)
                {
                    contractRepository = new GenericRepository<ContractEntity>(_context);
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
