using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Contact
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

        public Contact(String name, String lastName, String address, String city, String state, String zip, String phone, String email)
        {
            Name = name;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            Email = email;
        }

        public void PrintContact()
        {
            Console.WriteLine($"Name: {Name + LastName} \nAddress: {Address}\nCity: {City}\nState: {State}\nZip: {Zip}\nPhone Number: {Phone}\nEmail: {Email}");
        }
    }
}
