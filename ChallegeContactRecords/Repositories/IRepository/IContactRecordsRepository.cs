using ChallegeContactRecords.WebApi.Entities;
using ChallegeContactRecords.WebApi.Entities.DTOs;

namespace ChallegeContactRecords.WebApi.Repositories.IRepository
{
    public interface IContactRecordsRepository
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
