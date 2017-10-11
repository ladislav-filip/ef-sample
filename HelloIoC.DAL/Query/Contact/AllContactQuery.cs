using System.Collections.Generic;
using System.Linq;
using HelloIoC.DAL.DTO;
using HelloIoC.DAL.Repository;

namespace HelloIoC.DAL.Query
{
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
}