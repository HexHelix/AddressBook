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
        public Dictionary<String, List<String>> CityName { get; } = new Dictionary<String, List<String>>();
        public Dictionary<String, List<String>> StateName { get; } = new Dictionary<String, List<String>>();

        public Addressbook(string name)
        {
            Name = name;

        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
            if(!String.IsNullOrEmpty(contact.City))
            {
                if (CityName.ContainsKey(contact.City.ToUpper()))
                {
                    CityName[contact.City.ToUpper()].Add((contact.Name + contact.LastName));
                }
                else
                {
                    CityName[contact.City.ToUpper()] = new List<String>();
                    CityName[contact.City.ToUpper()].Add((contact.Name + contact.LastName));
                }
                if (StateName.ContainsKey(contact.State))
                {
                    StateName[contact.State.ToUpper()].Add((contact.Name + contact.LastName));
                }
                else
                {
                    StateName[contact.State.ToUpper()] = new List<String>();
                    StateName[contact.State.ToUpper()].Add((contact.Name + contact.LastName));
                }
            }


        }

        public void PrintNameByCityState()
        {
            foreach(var a in CityName)
            {
                Console.WriteLine($"Contacts in City {a.Key.ToUpper()} -- [{a.Value.Count}]");
                foreach(var b in a.Value)
                {
                    Console.WriteLine(b);
                }
            }
            foreach (var a in StateName)
            {
                Console.WriteLine($"Contacts in State {a.Key.ToUpper()} -- [{a.Value.Count}]");
                foreach (var b in a.Value)
                {
                    Console.WriteLine(b);
                }
            }
        }

        private void SortByName()
        {
           Contacts.Sort((x,y)=>x.Name.CompareTo(y.Name));
        }
        public override string ToString()
        {
            SortByName();
            string s;
            foreach(var contact in Contacts)
            {
                Console.WriteLine(contact.Name);
            }
            
            return "";
        }


    }
}
