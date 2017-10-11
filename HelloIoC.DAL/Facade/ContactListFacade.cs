using System;
using System.Collections.Generic;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Query;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL.Facade
{
    public class ContactListFacade
    {
        private readonly IRepository<ContactDTO> contactRepository;
        private readonly Func<AllContactQuery> allContactQueryFactory;

        public ContactListFacade(IRepository<ContactDTO> contactRepository, Func<AllContactQuery> allContactQueryFactory)
        {
            this.contactRepository = contactRepository;
            this.allContactQueryFactory = allContactQueryFactory;
        }

        public ContactDTO GetDetail(int id)
        {
            return contactRepository.GetById(id);
        }

        public IList<ContactDTO> GetAllContacts()
        {
            var contactQueryFactory = allContactQueryFactory();
            return contactQueryFactory.Execute();
        }
    }
}