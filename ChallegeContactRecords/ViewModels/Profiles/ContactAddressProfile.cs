using AutoMapper;
using ChallegeContactRecords.WebApi.Entities.DTOs;

namespace ChallegeContactRecords.WebApi.ViewModels.Profiles
{
    public class ContactAddressProfile : Profile
    {
        public ContactAddressProfile()
        {
           CreateMap<ContactAddressDTO, ContactAddressViewModel>().ReverseMap();
        }
    }
}
