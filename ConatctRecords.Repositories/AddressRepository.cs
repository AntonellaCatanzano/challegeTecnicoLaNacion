
using ChallegeContactRecords.WebApi.Repositories.IRepository;
using ContactRecords.DataAccess.Context;
using ContactRecords.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ChallegeContactRecords.WebApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public AddressRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> CreateAddress(Address address)
        {
            _dbContext.Add(address);

            await _dbContext.SaveChangesAsync();

            return address;
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            var addressList = await _dbContext.Address.AsNoTracking().ToListAsync();

            return addressList;
        }

        public async Task<Address> GetAddressByID(int id)
        {
            var address = await _dbContext.Address.Where(x => x.ID == id).FirstOrDefaultAsync();

            return address;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var addresses = GetAddressByID(address.ID);

            if (addresses != null)
            {
                _dbContext.Update(addresses);

                await _dbContext.SaveChangesAsync();
            }

            return address;

        }

        public void DeleteAddress(int id)
        {
            var address = _dbContext.Address.Find(id);

            if (address != null)
            {
                _dbContext.Remove(address);

                _dbContext.SaveChanges();
            }
        }
    }
}
