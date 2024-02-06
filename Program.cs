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
        static String name;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the address book");
            Console.WriteLine("Enter the name of the address book: ");
            name = Console.ReadLine();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Add Contact\n2. Edit Contact\n3. Delete Contact\n4. Exit");
                var inp = Console.ReadLine();
                switch (inp)
                {
                    case "1":
                        {
                            AddContact();
                            break;
                        }
                    case "2":
                        {
                            EditContact();
                            break;
                        }
                    case "3":
                        {
                            DeleteContact();
                            break;
                        }
                    case "4":
                        {
                            flag = false;
                            break;
                        }
                    default:
                        break;
                }

            }

            

        }

        static void AddContact()
        {

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
                Console.WriteLine("");
            }
            
        }
        static void EditContact()
        {
            Console.Clear();
            Console.Write("Enter the name of the contact you want to edit: ");
            var inp = Console.ReadLine();
            
            foreach (Contact a in addressBooks[name].Contacts)
            {
                if(a.Name == inp)
                {
                    a.EditContact();
                        break;
                }
            }

        }

        static void DeleteContact()
        {
            Console.Clear();
            Console.Write("Enter the name of the contact you want to Delete: ");
            var inp = Console.ReadLine();
            var i = 0;
            bool flag = false;

            foreach (Contact a in addressBooks[name].Contacts)
            {
                if (a.Name == inp)
                {
                    addressBooks[name].Contacts.RemoveAt(i);
                    flag = true;
                    break;
                }
                i++;
            }
            if (flag) { Console.WriteLine("Contact Deleted."); }
            else { Console.WriteLine("No contact of this name!"); }


        }
        
    }
}
