using ChallegeContactRecords.WebApi.Business.IServices;
using ChallegeContactRecords.WebApi.Entities;
using ChallegeContactRecords.WebApi.Repositories.IRepository;
using ChallegeContactRecords.WebApi.ViewModels;
using AutoMapper;
using ChallegeContactRecords.WebApi.Entities.DTOs;

namespace ChallegeContactRecords.WebApi.Business.Services
{
    public class ContactRecordsService : IContactRecordsService
    {
        private readonly IContactRecordsRepository _contactRecordsRepository;

        public ContactRecordsService(IContactRecordsRepository contactRecordsRepository)
        {
            _contactRecordsRepository = contactRecordsRepository;
        }

        public async Task<ContactsRecord> CreateContactRecord(ContactsRecord contactRecord)
        {
            return await _contactRecordsRepository.CreateContactRecord(contactRecord);            
        }

        public async Task<ContactsRecord> GetContactRecordByID(int id)
        {
            return await _contactRecordsRepository.GetContactRecordByID(id);
        }            

        public async Task<List<ContactAddressDTO>> GetContactRecordsByStateOrCity(string state, string city)
        {
            return await _contactRecordsRepository.GetContactRecordsByStateOrCity(state, city);
        }

        public async Task<ContactsRecord> SearchRecordByEmailOrPhoneNumber(string email, string? workPhoneNumber, string personalPhoneNumber)
        {
            return await _contactRecordsRepository.SearchRecordByEmailOrPhoneNumber(email, workPhoneNumber, personalPhoneNumber);
        }

        public async Task<ContactsRecord> UpdateContactRecord(ContactsRecord contactRecord)
        {
            return await _contactRecordsRepository.UpdateContactRecord(contactRecord);
        }

        public void DeleteContactRecord(int id)
        {
          _contactRecordsRepository.DeleteContactRecord(id);
        }

        public Task<List<ContactsRecord>> SelectAll()
        {
            return _contactRecordsRepository.SelectAll();
        }


    }
}
