using ContactRecords.Entities.Models;

namespace ChallegeContactRecords.WebApi.Repositories.IRepository
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task<List<Address>> GetAllAddresses();
        Task<Address> GetAddressByID(int id);
        void DeleteAddress(int id);
    }
}
