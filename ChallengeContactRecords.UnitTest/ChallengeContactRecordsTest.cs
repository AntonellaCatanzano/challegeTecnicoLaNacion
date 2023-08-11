using ContactRecords.Entities.Models;
using ContactRecords.WebApi.Controllers;

namespace ChallengeContactRecords.UnitTest
{   


    [TestClass]
    public class ChallengeContactRecordsTest
    {
        private readonly ContactRecordsController _controller;

        public ChallengeContactRecordsTest(ContactRecordsController controller)
        {
            _controller = controller;
        }

        [TestMethod]
        public void ChallengeContactRecordsTest_SelectAllContactRecords()
        {
            var result = _controller.SelectAll();

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ChallengeContactRecordsTest_CreateContactRecords()
        {
            ContactsRecord contact = new ContactsRecord();

            contact.Name = "Karina";
            contact.Company = "Sura";
            contact.Email = "karina@outlook.com";
            contact.AddressName = "Salta 951";
            contact.AddressID = 3;
            contact.PersonalPhoneNumber = "1150238954";
            contact.WorkPhoneNumber = "42157532";
            contact.ProfilePicture = "";

            var result = _controller.CreateContactRecord(contact);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChallengeContactRecordsTest_GetContactRecordsByID()
        {
            /*var result = _controller.GetById(2);

            Assert.IsNotNull(result);*/
        }

        [TestMethod]
        public void ChallengeContactRecordsTest_SearchContactRecordsByEmailOrPhoneNumber()
        {
            /*var result = _controller.SearchByEmailOrPhoneNumber("acatanzanoi@gmail.com","42183993", "1154950675");

            Assert.IsNotNull(result);*/
        }

        [TestMethod]
        public void ChallengeContactRecordsTest_GetContactRecordsBySameStateOrCity()
        {
            var result = _controller.GetContactRecordsByStateOrCity("Avellaneda", "Wilde");

            Assert.IsNotNull(result);
        }

        /*[TestMethod]
       public void ChallengeContactRecordsTest_DeleteContactRecords()
       {
           var result = _controller.DeleteContactRecords(1);

           Assert.IsNotNull(result);
       }*/

        [TestMethod]
        public void ChallengeContactRecordsTest_UpdateContactRecords()       
        {
           
           
        }

       
    }
}