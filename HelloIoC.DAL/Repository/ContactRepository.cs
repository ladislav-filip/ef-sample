using System;
using System.Linq;
using System.Linq.Expressions;
using HelloIoC.DAL.DTO;

namespace HelloIoC.DAL.Repository
{
    public class ContactRepository
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

    public class Mapper
    {
        public ContactDTO MapContactToContactDTO(Contact contact)
        {
            return MapContactToContactDTOExpression.Compile()(contact);
        }

        public Expression<Func<Contact, ContactDTO>> MapContactToContactDTOExpression { get; } = c => new ContactDTO
        {
            Id = c.Id,
            Name = c.Firstname + " " + c.Lastname,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber
        };
    }
}