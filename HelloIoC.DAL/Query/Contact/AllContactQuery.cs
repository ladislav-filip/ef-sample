using System.Collections.Generic;
using System.Linq;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL.Query
{
    public class ContactFirstLevelQuery : IFirstLevelQuery<Contact>
    {
        public IQueryable<Contact> GetSource(ContactDbContext db)
        {
            return db.Contacts;
        }
    }

    public class AllContactQuery : IQuery<ContactDTO>
    {
        private readonly ContactFirstLevelQuery contactFirstLevelQuery;
        private readonly Mapper mapper;
        public int PageSize { get; }
        public int PageIndex { get; }

        public AllContactQuery(ContactFirstLevelQuery contactFirstLevelQuery, Mapper mapper)
        {
            this.contactFirstLevelQuery = contactFirstLevelQuery;
            this.mapper = mapper;
        }

        public IList<ContactDTO> Execute()
        {
            using (var db = new ContactDbContext())
            {
                return contactFirstLevelQuery.GetSource(db)
                                             .Select(mapper.MapContactToContactDTOExpression)
                                             .ToList();
            }
        }
    }

    public class FilterContactByEmail : IFilterQuery<string, ContactDTO>
    {
        private readonly ContactFirstLevelQuery firstLevelQuery;
        private readonly Mapper mapper;
        public int PageSize { get; }
        public int PageIndex { get; }

        public FilterContactByEmail(ContactFirstLevelQuery firstLevelQuery, Mapper mapper)
        {
            this.firstLevelQuery = firstLevelQuery;
            this.mapper = mapper;
        }

        public IList<ContactDTO> Execute()
        {
            using (var db = new ContactDbContext())
            {
                return firstLevelQuery.GetSource(db)
                                      .Where(c => c.Email.Contains(Filter))
                                      .Select(mapper.MapContactToContactDTOExpression).ToList();
            }
        }

        public string Filter { get; set; }
    }
}