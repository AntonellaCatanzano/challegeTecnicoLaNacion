using ChallegeContactRecords.WebApi.Entities.DTOs;
using ChallegeContactRecords.WebApi.Entities;

namespace ChallegeContactRecords.WebApi.Business.IServices
{
    public interface IContactRecordsService 
    {
        Task<ContactsRecord> CreateContactRecord(ContactsRecord contactRecord);
        Task<ContactsRecord> UpdateContactRecord(ContactsRecord contactRecord);
        Task<ContactsRecord> GetContactRecordByID(int id);
        Task<ContactsRecord> SearchRecordByEmailOrPhoneNumber(string email, string? workPhoneNumber, string personalPhoneNumber);
        Task<List<ContactAddressDTO>> GetContactRecordsByStateOrCity(string state, string city);
        void DeleteContactRecord(int id);
        Task<List<ContactsRecord>> SelectAll();

    }
}
