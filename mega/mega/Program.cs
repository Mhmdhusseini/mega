using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Contact
{
    public string PhoneNumber { get; set; }
}

class Program
{
    static List<Contact> contacts = new List<Contact>();
    static string filePath = "contacts.csv";

    static void Main()
    {
        LoadContacts();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Contact Book");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Delete Contact");
            Console.WriteLine("3. Show All Contacts");
            Console.WriteLine("4. Search Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddContact(); break;
                case "2": DeleteContact(); break;
                case "3": ShowContacts(); break;
                case "4": SearchContact(); break;
                case "5": SaveContacts(); return;
                default: Console.WriteLine("Invalid option! Press any key to continue..."); Console.ReadKey(); break;
            }
        }
    }

    static void AddContact()
    {
        Console.Write("Enter Phone Number, must be (11 digits): ");
        string phone = Console.ReadLine();

        if (phone.Length == 11 )
        {
            contacts.Add(new Contact { PhoneNumber = phone });
            SaveContacts();
            Console.WriteLine("Contact added");
        }
        else
        {
            Console.WriteLine("Invalid, must be 11 digits ");
        }
        Console.ReadKey();
    }

    static void DeleteContact()
    {
        Console.Write("Enter phone number to delete: ");
        string phone = Console.ReadLine();
        var contact = contacts.FirstOrDefault(c => c.PhoneNumber == phone);
        if (contact != null)
        {
            contacts.Remove(contact);
            SaveContacts();
            Console.WriteLine("Contact deleted ");
        }
        else
        {
            Console.WriteLine("Contact not found ");
        }
        Console.ReadKey();
    }

    static void ShowContacts()
    {
        Console.WriteLine("Saved Contacts: ");
        if (contacts.Any())
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.PhoneNumber);
            }
        }
        else
        {
            Console.WriteLine("No contacts available ");
        }
        Console.ReadKey();
    }

    static void SearchContact()
    {
        Console.Write("Enter phone number to search: ");
        string contact_input = Console.ReadLine();
        var results = contacts.Where(c => c.PhoneNumber.Contains(contact_input)).ToList();

        if (results.Any())
        {
            foreach (var contact in results)
            {
                Console.WriteLine(contact.PhoneNumber);
            }
        }
        else
        {
            Console.WriteLine("No contacts found ");
        }
        Console.ReadKey();
    }

    static void SaveContacts()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var contact in contacts)
            {
                writer.WriteLine(contact.PhoneNumber);
            }
        }
    }

    static void LoadContacts()
    {
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                contacts.Add(new Contact { PhoneNumber = line });
            }
        }
    }
}
