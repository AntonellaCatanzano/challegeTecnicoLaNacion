using ChallegeContactRecords.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallegeContactRecords.WebApi.ViewModels
{
    public class ContactRecordViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string? ProfilePicture { get; set; }

        public string Email { get; set; }

        public string? WorkPhoneNumber { get; set; }

        public string PersonalPhoneNumber { get; set; }
        public int? AddressID { get; set; }
        public string AddressName { get; set; }
        public virtual Address Address { get; set; }
    }
}
