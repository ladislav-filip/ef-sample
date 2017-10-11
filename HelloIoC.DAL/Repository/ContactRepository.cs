using System.Linq;
using HelloIoC.DAL.DTO;

namespace HelloIoC.DAL.Repository
{
    public class ContactRepository : IRepository<ContactDTO>
    {
        private readonly Mapper mapper;

        public ContactRepository(Mapper mapper)
        {
            this.mapper = mapper;
        }

        public ContactDTO GetById(int id)
        {
            using (var db = new ContactDbContext())
            {
                //() => Email
                //var memberExpression = mapper.MapContactToContactDTOExpression.Body as MemberExpression;
                //memberExpression.Member.Name
                
                //var contactDTO = db.Contacts.Select(mapper.MapContactToContactDTOExpression).FirstOrDefault(c => c.Id == id);
                //return contactDTO;

                var contact = db.Contacts.Find(id);
                return mapper.MapContactToContactDTO(contact);
            }
        }
    }
}