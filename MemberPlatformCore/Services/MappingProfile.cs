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
                //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                //.ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.IdentityNumber))
                //.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                //.ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                //.ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                //.ForMember(dest => dest.InsuranceCompany, opt => opt.MapFrom(src => src.InsuranceCompany))
                //.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                //.ForMember(dest => dest.PrivacyApproval, opt => opt.MapFrom(src => src.PrivacyApproval))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.Box, opt => opt.MapFrom(src => src.Address.Box))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.AddressType, opt => opt.MapFrom(src => src.Address.AddressType.Name))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.Id))
                .ReverseMap();


            CreateMap<AddressEntity, Address>()
                .ReverseMap()
                .ForPath(x => x.AddressType.Name, opt => opt.Ignore())
                .ForPath(x => x.AddressType.OptionTypeId, opt => opt.Ignore());



            CreateMap<OptionEntity, Option>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.OptionType, opt => opt.MapFrom(src => src.OptionType.Name))
                .ReverseMap();

            CreateMap<OptionTypeEntity, OptionType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

        }
    }
}
