using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Addressbook
    {
        public String Name { get; set; }
        public List<Contact> Contacts { get; } = new List<Contact>();

        public Addressbook(string name)
        {
            Name = name;

        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        
    }
}
