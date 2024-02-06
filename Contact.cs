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
            Console.WriteLine($"1.Name: {Name + LastName} \n2.Address: {Address}\n3.City: {City}\n4.State: {State}\n5.Zip: {Zip}\n6.Phone Number: {Phone}\n7.Email: {Email}");
        }
        public void EditContact()
        {

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the corresponding number to edit that field....\nPress x to return to main menu.");
                PrintContact();
                var inp = Console.ReadLine();
                switch (inp)
                {
                    case "1":
                        {
                            Console.Write("Enter First Name: ");
                            String FName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            String LName = Console.ReadLine();
                            Name = FName;
                            LastName = LName;
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter Address: ");
                            String Address = Console.ReadLine();
                            this.Address = Address;
                            break;


                        }
                    case "3":
                        {
                            Console.Write("Enter City: ");
                            String City = Console.ReadLine();
                            this.City = City;
                            break;

                        }
                    case "4":
                        {
                            Console.Write("Enter State: ");
                            String State = Console.ReadLine();
                            this.State = State;
                            break;

                        }
                    case "5":
                        {
                            Console.Write("Enter Zip: ");
                            String Zip = Console.ReadLine();
                            this.Zip = Zip;
                            break;

                        }
                    case "6":
                        {
                            Console.Write("Enter phone number: ");
                            String PhoneNumber = Console.ReadLine();
                            this.Phone = PhoneNumber;
                            break;

                        }
                    case "7":
                        {
                            Console.Write("Enter Email: ");
                            String Email = Console.ReadLine();
                            this.Email = Email;
                            break;
                        }
                    case "x":
                        {
                            flag = false;
                            break;
                        }
                    default:
                        break;
                }

            }


        }

        public bool Equals(String n)
        {
            if(n == (Name + LastName))return true;
            else return false;
        }
    }
}
