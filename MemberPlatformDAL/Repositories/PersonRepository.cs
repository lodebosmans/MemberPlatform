using MemberPlatformDAL.Data;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Repositories
{
    public class PersonRepository : GenericRepository<PersonEntity>, IPersonRepository
    {
        private DataContext _context;

        public PersonRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync()
        {
            return await _context.Persons
                .Include(p => p.Address)
                .ThenInclude(a => a.AddressType)
                .ToListAsync();
        }

        public async override Task<PersonEntity> GetByIdAsync(int id)
        {
            return await _context.Persons
           .Include(p => p.Address)
           .ThenInclude(a => a.AddressType)
           .Where(x => x.Id == id)
           .SingleAsync();
            

        }
        public async Task<PersonEntity> SaveAsync(PersonEntity personEntity, int addressId)
        {
            personEntity.AddressId = addressId;
            _context.Persons.Add(personEntity);
            await _context.SaveChangesAsync();
            return personEntity;
        }

        //public async Task<PersonEntity> UpdateAsync(PersonEntity entity)
        //{
        //    _context.Persons.Update(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task DeleteAsync(PersonEntity entity)
        //{
        //    _context.Persons.Remove(entity);
        //    await _context.SaveChangesAsync();
        //}
    }
}
