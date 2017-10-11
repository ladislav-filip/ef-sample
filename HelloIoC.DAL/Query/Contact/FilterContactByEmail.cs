using System.Collections.Generic;
using System.Linq;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL.Query
{
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
                    .Select(mapper.MapContactToContactDTOExpression)
                    .ToList();
            }
        }

        public string Filter { get; set; }
    }
}