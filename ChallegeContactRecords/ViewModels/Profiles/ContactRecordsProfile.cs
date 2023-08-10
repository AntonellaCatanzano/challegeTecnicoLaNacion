using AutoMapper;
using ChallegeContactRecords.WebApi.Entities;
using ChallegeContactRecords.WebApi.ViewModels;

namespace ChallegeContactRecords.WebApi.ViewModels.Profiles
{
    public class ContactRecordsProfile : Profile
    {
        public ContactRecordsProfile()
        {
            CreateMap<ContactsRecord, ContactRecordViewModel>().ReverseMap();
        }
    }
}
