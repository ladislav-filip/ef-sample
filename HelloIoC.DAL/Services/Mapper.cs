using System;
using System.Linq.Expressions;
using HelloIoC.DAL.DTO;

namespace HelloIoC.DAL.Repository
{
    public class Mapper
    {
        public ContactDTO MapContactToContactDTO(Contact contact)
        {
            var method = MapContactToContactDTOExpression.Compile();
            return method(contact);
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