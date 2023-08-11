using ChallegeContactRecords.WebApi.Business.IServices;
using ContactRecords.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactRecords.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRecordsController : ControllerBase
    {

        private readonly IContactRecordsService _contactRecordsService;

        public ContactRecordsController(IContactRecordsService contactRecordsService)
        {
            _contactRecordsService = contactRecordsService;
        }
        

       
        
        /// <summary>
        /// Devuelve todos los registros de la tabla ContactRecords
        /// </summary>        
        /// <response code="200">Devuelve el listado de todos los registros de contacto</response>
        /// <response code="404">Si no encuentra los datos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContactsRecord>))]
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

                return NotFound();

            }
        }

        /// <summary>
        /// Agrega un nuevo registro de Contacto
        /// </summary>        
        /// <response code="200">Inserta el registro de contactos corectamente</response>
        /// <response code="404">Si no se pudo agregar un registro de contactos</response>        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactsRecord))]
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

        /// <summary>
        /// Mofifica un registro de Contacto ya existente
        /// </summary>        
        /// <response code="200">Modifica el registro de contactos corectamente</response>
        /// <response code="404">Si ya existe el registro de contactos</response>        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactsRecord))]
        [HttpPut]
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

        /// <summary>
        /// Devuelve un registro de contacto buscando por email o número de teléfono
        /// </summary>        
        /// <response code="200">Devuelve un registro de contactos ingresando un email o un número de télefono existente</response>
        /// <response code="404">Si no encuentra la información</response>        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactsRecord))]
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

        /// <summary>
        /// Devuelve un listado de registro de contacto con el mismo estado o ciudad
        /// </summary>        
        /// <response code="200">Devuelve los registros de contactos que son de la misma ciudad o estado</response>
        /// <response code="404">Si no encuentra información</response>        
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

        /// <summary>
        /// Elimina un registro de contacto según id
        /// </summary>        
        /// <response code="200">Elimina el contacto si existe</response>
        /// <response code="404">Si no encuentra información</response>        
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
