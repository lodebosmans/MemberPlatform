using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MemberPlatformCore.Services
{
    public class PersonAddressService : IPersonAddressService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private IMapper _mapper;

        public PersonAddressService(
            IPersonRepository personRepository,
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task SaveDataAsync(
            Person person, Address address)
        {
            PersonEntity personEntity = _mapper.Map<PersonEntity>(person);
            AddressEntity addressEntity = _mapper.Map<AddressEntity>(address);
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                await _addressRepository.Insert(addressEntity);
                var savedAddress = await _addressRepository.GetByIdAsync(addressEntity.Id);
                await _personRepository.SaveAsync(personEntity, savedAddress.Id);


                transaction.Complete();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to save data.", ex);
            }
        }
    }
}
