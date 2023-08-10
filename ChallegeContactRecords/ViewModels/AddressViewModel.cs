using ChallegeContactRecords.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallegeContactRecords.WebApi.ViewModels
{
    public class AddressViewModel
    {
        public int ID { get; set; }

        public string Country { get; set; }

        public string States { get; set; }

        public string City { get; set; }

        public virtual ICollection<ContactsRecord> ContactsRecord { get; set; }
    }
}
