using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Facade;
using HelloIoC.DAL.Query;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = new Mapper();

            var contactListFacade = new ContactListFacade(new ContactRepository(mapper), () => new AllContactQuery(new ContactFirstLevelQuery(), mapper));

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
