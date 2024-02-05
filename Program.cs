using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        static Dictionary<String, Addressbook> addressBooks = new Dictionary<string, Addressbook>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book");
            bool IsRunning = true;

            while (IsRunning)
            {
                Console.WriteLine("1. Add Contact\nPress 'x' to exit.");
                var inp = Console.ReadLine();

                switch (inp)
                {
                    case "1":
                        {
                            AddContact();
                            break;
                        }
                    case "x":
                        {
                            IsRunning = false;
                            break;
                        }
                    default:
                        break;
                }
            }


            

        }

        static void AddContact()
        {
            Console.WriteLine("Enter the name of the address book: ");
            String name = Console.ReadLine();
            if (addressBooks.ContainsKey(name))
            {
                Console.WriteLine("addressBook name is already used");
            }
            else
            {
                addressBooks.Add(name,new Addressbook(name));
                Console.WriteLine("Address book successfully created!");
            }
            Console.Write("Enter First Name: ");
            String FName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            String LName = Console.ReadLine();
            Console.Write("Enter Address: ");
            String Address = Console.ReadLine();
            Console.Write("Enter City: ");
            String City = Console.ReadLine();
            Console.Write("Enter State: ");
            String State = Console.ReadLine();
            Console.Write("Enter Zip: ");
            String Zip = Console.ReadLine();
            Console.Write("Enter phone number: ");
            String PhoneNumber = Console.ReadLine();
            Console.Write("Enter Email: ");
            String Email = Console.ReadLine();

            addressBooks[name].AddContact(new Contact(FName, LName, Address, City,State, Zip, PhoneNumber, Email));

            foreach( Contact cntc in addressBooks[name].Contacts)
            {
                cntc.PrintContact();
            }
            
        }
    }
}
