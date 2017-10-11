using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloIoC.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class ContactDbContext : DbContext
    {
        public IDbSet<Contact> Contacts { get; set; }

        public ContactDbContext() :base("ContactDb")
        {
            
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
