using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddressBook
{
    internal class Program
    {
        static Dictionary<String, Addressbook> addressBooks = new Dictionary<string, Addressbook>();
        static String name = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the address book");
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine($"Current Address Book: {name}");
                Console.WriteLine("1. Select Address Book\n2. Add Address Book\n3. Add Contact\n4. Edit Contact\n5. Delete Contact\n6. Search contacts by city or state\n7. Display Contacts by City and State\n8. Exit");
                var inp = Console.ReadLine();
                switch (inp)
                {
                    case "1":
                        {
                            SelectAddressbook();
                            break;
                        }
                    case "2":
                        {
                            AddAddressbooks();
                            break;
                        }
                    case "3":
                        {
                            AddContact();
                            break;
                        }
                    case "4":
                        {
                            EditContact();
                            break;
                        }
                    case "5":
                        {
                            DeleteContact();
                            break;
                        }
                    case "8":
                        {
                            flag = false;
                            break;
                        }
                    case "6":
                        {
                            SearchByCityState();
                            break;
                        }
                    case "7":
                        {
                            Console.Clear();
                            if (name == null || !addressBooks.ContainsKey(name)) break;
                            addressBooks[name].PrintNameByCityState();
                            Console.ReadLine();
                            break;
                        }
                    default:
                        break;
                }

            }

            

        }

        static void AddAddressbooks()
        {
            //Console.WriteLine(addressBooks.Count());

            Console.Write("Enter the name of the address book: ");
            var inp = Console.ReadLine();
            if (addressBooks.ContainsKey(inp))
            {
                Console.WriteLine("addressBook name is already used");
                Thread.Sleep(1500);
            }
            else
            {
                addressBooks.Add(inp, new Addressbook(inp));
                Console.WriteLine($"Address book {inp} successfully created!");
                Thread.Sleep(1500);
            }


        }

        static void AddContact()
        {
            if (name == null || !addressBooks.ContainsKey(name)) return;


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

            foreach(var a in addressBooks[name].Contacts)
            {
                if (a.Equals((FName + LName))){
                    Console.WriteLine("Contact with same name already exists!");
                    Thread.Sleep(1000);
                    return;
                }

            } 

            addressBooks[name].AddContact(new Contact(FName, LName, Address, City,State, Zip, PhoneNumber, Email));

            foreach( Contact cntc in addressBooks[name].Contacts)
            {
                Console.WriteLine("");
                cntc.PrintContact();
                Console.WriteLine("");
            }
            Thread.Sleep(1000);
            
        }
        static void EditContact()
        {
            Console.Clear();
            if (name == null || !addressBooks.ContainsKey(name)) return;
            Console.Write("Enter the name of the contact you want to edit: ");
            var inp = Console.ReadLine();
            bool flag = false;

            foreach (Contact a in addressBooks[name].Contacts)
            {
                if(a.Name == inp)
                {
                    a.EditContact();
                    flag = true;
                    break;
                }
            }
            if (flag) { Console.WriteLine("Contact Found."); }
            else { Console.WriteLine("No contact of this name!"); }

        }

        static void DeleteContact()
        {
            Console.Clear();
            if (name == null || !addressBooks.ContainsKey(name)) return;
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
        static void SelectAddressbook()
        {
            Console.Clear();
            Console.WriteLine("Available Address Books");
            foreach (var a in addressBooks)
            {
                Console.WriteLine(a.Key);
            }
            Console.WriteLine("Type the name of the address book you want to use:");
            var inp = Console.ReadLine();
            if (addressBooks.ContainsKey(inp))
            {
                name = inp;
                Console.WriteLine($"Using Address book: {name}");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine($"Address book {inp} not created.");
                Thread.Sleep(1500);
            }



        }

        static void SearchByCityState()
        {
            Console.Write("Enter city or state name: ");
            String inp = Console.ReadLine().ToLower();
            foreach (var a in addressBooks)
            {
                foreach (var b in addressBooks[a.Key].Contacts)
                {
                    if (inp == b.City.ToLower() || inp == b.State.ToLower())
                    {
                        Console.WriteLine($"{b.Name + " " + b.LastName} (Address book -> {a.Key})");
                    }
                }
            }
            Console.ReadLine();
        }
        
    }
}
