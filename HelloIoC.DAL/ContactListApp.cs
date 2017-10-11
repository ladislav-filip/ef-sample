using System;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Facade;
using HelloIoC.DAL.Query;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL
{
    class ContactListApp
    {
        private readonly ContactListFacade contactListFacade;

        public ContactListApp(ContactListFacade contactListFacade)
        {
            this.contactListFacade = contactListFacade;
        }

        public void App()
        {
            //var mapper = new Mapper();
            //contactListFacade = new ContactListFacade(new ContactRepository(mapper),
            //    () => new AllContactQuery(new ContactFirstLevelQuery(), mapper));

            var contact1 = contactListFacade.GetDetail(1);
            PrintContactDetail(contact1);

            foreach (var contact in contactListFacade.GetAllContacts())
            {
                PrintContactDetail(contact);
            }
        }

        private static void PrintContactDetail(ContactDTO contact)
        {
            Console.WriteLine($"{contact.Name}: {contact.Email}");
        }
    }
}