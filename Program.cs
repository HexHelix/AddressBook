﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using CsvHelper;
using System.Globalization;

namespace AddressBook
{
    internal class Program
    {
        static Dictionary<String, Addressbook> addressBooks = new Dictionary<string, Addressbook>();
        static String name = null;
        static string filePath = "address_book.bin";
        static string filePathCsv = "address_book.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the address book");
            bool flag = true;
            ReadAddressBookFromFile();
            while (flag)
            {
                Console.Clear();
                Console.WriteLine($"Current Address Book: {name}");
                Console.WriteLine("1. Select Address Book\n2. Add Address Book\n3. Add Contact\n4. Edit Contact\n5. Delete Contact\n6. Search contacts by city or state\n7. Display Contacts by City and State\n8. Sort Contacts\n9. Sort By Name\n10.Exit");
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
                    case "10":
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
                    case "8":
                        {
                            SortByName();
                            break;
                        }
                    case "9":
                        {
                            SortByName();
                            break;
                        }
                    default:
                        break;
                }

            }

            

        }

        static void ReadAddressBookFromFile()
        {
            /*            if (!File.Exists(filePath))
                        {
                            return; // No file, nothing to read
                        }

                        using (FileStream stream = File.OpenRead(filePath))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            try
                            {
                                addressBooks = (Dictionary<string, AddressBook.Addressbook>)formatter.Deserialize(stream);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error reading address book from file: " + ex.Message);
                            }
                        }*/
/*            if (!File.Exists(filePath))
            {
                return; // No file, nothing to read
            }

            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) // Optional for locale-specific handling
                {
                    try
                    {
                        addressBooks = csv.GetRecords<AddressBook.Addressbook>().ToDictionary(a => a.Name);
                    }
                    catch (CsvHelperException ex)
                    {
                        Console.WriteLine("Error reading CSV file: {0}", ex.Message);
                    }
                }
            }*/
        }

        static void SaveAddressBookToFile()
        {
/*            using (FileStream stream = File.OpenWrite(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, addressBooks);
                Console.WriteLine("Address book saved successfully.");
            }*/

            using (var writer = new StreamWriter(filePathCsv))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) // Assuming desired culture
                {
                    csv.WriteField("AddressBook Name");
                    csv.WriteField("Contact Name");
                    csv.WriteField("Address");
                    csv.WriteField("City");
                    csv.WriteField("State");
                    csv.WriteField("Zip");
                    csv.WriteField("Phone");
                    csv.WriteField("Email");
                    csv.NextRecord();

                    foreach (var a in addressBooks)
                    {
                        foreach (var b in addressBooks[a.Key].Contacts)
                        {
                            csv.WriteField(a.Key);
                            csv.WriteField(b.Name + b.LastName);
                            csv.WriteField(b.Address);
                            csv.WriteField(b.City);
                            csv.WriteField(b.State);
                            csv.WriteField(b.Zip);
                            csv.WriteField(b.Phone);
                            csv.WriteField(b.Email);
                            csv.NextRecord();
                        }
                    }


                    csv.WriteRecords(addressBooks); // Write address book records
                    Console.WriteLine("Address book saved successfully.");
                }
            }
        }
        static void AddAddressbooks()
        {
            //Console.WriteLine(addressBooks.Count());
            ReadAddressBookFromFile();
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
            SaveAddressBookToFile();


        }

        static void AddContact()
        {
            if (name == null || !addressBooks.ContainsKey(name)) return;
            ReadAddressBookFromFile();


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
            SaveAddressBookToFile();
            Thread.Sleep(1000);
            
        }
        static void EditContact()
        {
            Console.Clear();
            if (name == null || !addressBooks.ContainsKey(name)) return;
            ReadAddressBookFromFile();
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
            SaveAddressBookToFile();

        }

        static void DeleteContact()
        {
            Console.Clear();
            
            if (name == null || !addressBooks.ContainsKey(name)) return;
            ReadAddressBookFromFile();
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
            SaveAddressBookToFile();


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

        static void SortByName()
        {
            addressBooks[name].ToString();
            Console.ReadLine();
        }

        static void SortByCity()
        {
            addressBooks[name].SortByCity();
            addressBooks[name].ToString();
            Console.ReadLine();
        }

        static void SortByState()
        {
            addressBooks[name].SortByState();
            addressBooks[name].ToString();
            Console.ReadLine();
        }

        static void SortByZip()
        {
            addressBooks[name].SortByZip();
            addressBooks[name].ToString();
            Console.ReadLine();
        }

    }
}
