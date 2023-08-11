using ChallegeContactRecords.WebApi.Entities;
using ContactRecords.Entities.Models;

namespace ChallegeContactRecords.WebApi.Business.IServices
{
    public interface IAddressService
    {
        Task<Address> Create(Address address);
        Task<Address> Update(Address address);

        Task<List<Address>> GetAll();
        Task<Address> GetByID(int id);
        void Delete(int id);
    }
}
