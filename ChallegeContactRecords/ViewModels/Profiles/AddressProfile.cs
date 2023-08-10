using AutoMapper;
using ChallegeContactRecords.WebApi.Entities;

namespace ChallegeContactRecords.WebApi.ViewModels.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();              
        }
    }
}
