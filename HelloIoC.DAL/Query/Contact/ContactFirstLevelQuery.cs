using System.Linq;

namespace HelloIoC.DAL.Query
{
    public class ContactFirstLevelQuery : IFirstLevelQuery<Contact>
    {
        public IQueryable<Contact> GetSource(ContactDbContext db)
        {
            return db.Contacts;
        }
    }
}