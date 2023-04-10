using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;

namespace MemberPlatformCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonEntity, Person>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.Box, opt => opt.MapFrom(src => src.Address.Box))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.Id))
                .ForMember(dest => dest.AddressTypeId, opt => opt.MapFrom(src => src.Address.AddressType.Id))
                .ReverseMap()
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
                .ForPath(dest => dest.Address.Box, opt => opt.MapFrom(src => src.Box))
                .ForPath(dest => dest.Address.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
                .ForPath(dest => dest.Address.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Address.AddressType.Id, opt => opt.MapFrom(src => src.AddressTypeId));

            CreateMap<AddressEntity, Address>()
                .ReverseMap();

            CreateMap<ContractEntity, Contract>()
                .ReverseMap();

            CreateMap<ContractPersonInvolvementEntity, ContractPersonInvolvement>()
                .ReverseMap();

            CreateMap<PriceAgreementEntity, PriceAgreement>()
                .ReverseMap();

            CreateMap<ProductAgreementEntity, ProductAgreement>()
                .ReverseMap();

            CreateMap<ProductDefinitionEntity, ProductDefinition>()
                .ReverseMap();

            CreateMap<ProductUnitEntity, ProductUnit>()
                .ReverseMap();

            CreateMap<OptionEntity, Option>()
                .ReverseMap();

            CreateMap<OptionTypeEntity, OptionType>()
                .ReverseMap();

            CreateMap<SalesItemEntity, SalesItem>()
                .ReverseMap();

            CreateMap<TicketEntity, Ticket>()
                .ReverseMap();

            CreateMap<TicketItemEntity, TicketItem>()
                .ReverseMap();
        }
    }
}
