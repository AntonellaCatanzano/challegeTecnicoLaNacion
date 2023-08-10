using AutoMapper;
using ChallegeContactRecords.WebApi.Business.IServices;
using ChallegeContactRecords.WebApi.Business.Services;
using ChallegeContactRecords.WebApi.Entities;
using ChallegeContactRecords.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ChallegeContactRecords.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRecordsController : ControllerBase
    {
        private readonly IContactRecordsService _contactRecordsService;
	// Esto serviría para implementar el mapeo de las clases
        // private readonly IMapper _mapper;

        public ContactRecordsController(IContactRecordsService contactRecordsService)// , IMapper mapper)
        {
            _contactRecordsService = contactRecordsService;
            // _mapper = mapper;
        }

        [HttpGet]
        [Route("SelectAll")]
        public async Task<ActionResult<List<ContactsRecord>>> SelectAll()
        {
            try
            {
                var contact = await _contactRecordsService.SelectAll();
                

                return Ok(contact);
            }
            catch (Exception)
            {

                return null;

            }
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<ActionResult<ContactsRecord>> GetById(int id)        
	    {
            try
            {                
                var contact = await _contactRecordsService.GetContactRecordByID(id);

                if (contact == null)
                {
                   return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception)
            {

                return NotFound();

            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ContactsRecord>> CreateContactRecord(ContactsRecord contactRecord)
        {
            try
            {
                var contact = await _contactRecordsService.CreateContactRecord(contactRecord);                

                return Ok(contact);
            }
            catch (Exception)
            {

                return NotFound();

            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<ContactsRecord>> UpdateContactRecord(ContactsRecord contactRecord)
        {
            try
            {
                var contact = await _contactRecordsService.UpdateContactRecord(contactRecord);                

                return Ok(contact);
            }
            catch (Exception)
            {

                return NotFound();

            }
        }

	    [HttpGet]
        [Route("SearchByEmailOrPhoneNumber/{email}/{workPhoneNumber}/{personalPhoneNumber}")]
        public async Task<ActionResult<ContactsRecord>> SearchByEmailOrPhoneNumber(string email, string? workPhoneNumber, string personalPhoneNumber)        
	    {
            try
            {                
                var contact = await _contactRecordsService.SearchRecordByEmailOrPhoneNumber(email, workPhoneNumber, personalPhoneNumber);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception)
            {

                return NotFound();

            }
        }

	    [HttpGet]
        [Route("GetContactRecordsByStateOrCity/{state}/{city}")]
        public async Task<ActionResult<ContactsRecord>> GetContactRecordsByStateOrCity(string? state, string city)       
	    {
                try
                {                
                    var contact = await _contactRecordsService.GetContactRecordsByStateOrCity(state, city);

                    if (contact == null)
                    {
                        return NotFound();
                    }

                    return Ok(contact);
                }
                catch (Exception)
                {

                    return NotFound();

                }
        }

        /*[HttpDelete("{id}")]
        
        public void DeleteContactRecord(int id)
        {
            try
            {
                var contact = _contactRecordsService.GetContactRecordByID(id);

                if (contact != null)
                {
                    _contactRecordsService.DeleteContactRecord(id);                    
                }

                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();

            }
        }*/

    }
}
