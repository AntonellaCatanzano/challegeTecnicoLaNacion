
using ChallegeContactRecords.WebApi.Entities.DTOs;
using ChallegeContactRecords.WebApi.Repositories.IRepository;
using ContactRecords.DataAccess.Context;
using ContactRecords.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChallegeContactRecords.WebApi.Repositories
{
    /// <summary>
    /// Utilizamos Patrón de Repositorio inyectando el contexto
    /// </summary>
    public class ContactRecordsRepository : IContactRecordsRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ContactRecordsRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactsRecord> CreateContactRecord(ContactsRecord contactRecord)
        {

            var contact = await _dbContext.ContactsRecord.AddAsync(contactRecord);

            await _dbContext.SaveChangesAsync();

            return contact.Entity;
        }

        public async Task<ContactsRecord> GetContactRecordByID(int id)
        {

            var contact = await _dbContext.ContactsRecord.FirstOrDefaultAsync(x => x.ID == id);


            return contact;
        }

        public async Task<List<ContactAddressDTO>> GetContactRecordsByStateOrCity(string state, string city)
        {
            var contactRecordList = await (from c in _dbContext.ContactsRecord
                                           join a in _dbContext.Address
                                           on c.AddressID equals a.ID
                                           where a.City == city || a.States == state
                                           select new ContactAddressDTO
                                           {
                                               ContactName = c.Name,
                                               AddressName = c.AddressName,
                                               City = a.City,
                                               State = a.States,
                                               Company = c.Company,
                                               Email = c.Email,
                                               WorkPhoneNumber = c.WorkPhoneNumber,
                                               PersonalPhoneNumber = c.PersonalPhoneNumber,
                                               ProfilePicture = c.ProfilePicture

                                           }).ToListAsync();

            return contactRecordList;
        }

        public async Task<ContactsRecord> SearchRecordByEmailOrPhoneNumber(string email, string? workPhoneNumber, string personalPhoneNumber)
        {
            var contactRecord = await _dbContext.ContactsRecord.Where(x => x.Email == email || x.WorkPhoneNumber == workPhoneNumber || x.PersonalPhoneNumber == personalPhoneNumber).FirstOrDefaultAsync();

            return contactRecord;
        }

        public async Task<ContactsRecord> UpdateContactRecord(ContactsRecord contactRecord)
        {           

            var contact = await _dbContext.ContactsRecord.FirstOrDefaultAsync(e => e.ID == contactRecord.ID);            

            if (contact != null)
            {
                contact.ID = contactRecord.ID;
                contact.Name = contactRecord.Name;
                contact.Company = contactRecord.Company;
                contact.PersonalPhoneNumber = contactRecord.PersonalPhoneNumber;
                contact.WorkPhoneNumber = contact.WorkPhoneNumber;
                contact.Email = contactRecord.Email;
                contact.AddressName = contactRecord.AddressName;
                contact.AddressID = contactRecord.AddressID;
                contact.ProfilePicture = contactRecord.ProfilePicture;


                await _dbContext.SaveChangesAsync();

                return contact;
            }

            return null;
        }
        public void DeleteContactRecord(int id)
        {
            var contact = GetContactRecordByID(id);

            _dbContext.Remove(contact);

            _dbContext.SaveChangesAsync();
        }

        public async Task<List<ContactsRecord>> SelectAll()
        {
            return await _dbContext.ContactsRecord.ToListAsync();
        }
    }
}
