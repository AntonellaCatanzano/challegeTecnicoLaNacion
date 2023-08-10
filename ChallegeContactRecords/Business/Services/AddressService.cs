using ChallegeContactRecords.WebApi.Business.IServices;
using ChallegeContactRecords.WebApi.Entities;
using ChallegeContactRecords.WebApi.Repositories;
using ChallegeContactRecords.WebApi.Repositories.IRepository;

namespace ChallegeContactRecords.WebApi.Business.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> Create(Address address)
        {
            return await _addressRepository.CreateAddress(address);
        }

        public void Delete(int id)
        {
            _addressRepository.DeleteAddress(id);
        }

        public async Task<List<Address>> GetAll()
        {
            return await _addressRepository.GetAllAddresses();
        }

        public async Task<Address> GetByID(int id)
        {
            return await _addressRepository.GetAddressByID(id);
        }

        public async Task<Address> Update(Address address)
        {
            return await _addressRepository.UpdateAddress(address);
        }
    }
}
