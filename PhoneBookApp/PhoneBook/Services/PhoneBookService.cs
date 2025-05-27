using PhoneBook.Entities;
using PhoneBook.Enums;
using PhoneBook.Interfaces;
using PhoneBook.Utils;

namespace PhoneBook.Services;

public class PhoneBookService : IPhoneBookService
{
    private readonly Dictionary<Contact, List<PhoneCall>> _phoneBook;

    public PhoneBookService(Dictionary<Contact, List<PhoneCall>> phoneBook)
    {
        _phoneBook = phoneBook;
    }

    public void DisplayAllContacts()
    {
        var contacts = _phoneBook.Keys.ToList();
        
        if (contacts.Count == 0) Console.WriteLine("No contacts found.");

        foreach (var contact in contacts)
        {
            Console.WriteLine($" {contact.FullName} {contact.PhoneNumber} {contact.Preference.ToString()}");
        }
    }
    
    public void DisplayAllPhoneCalls()
    {
        foreach (var contact in _phoneBook.Keys.ToList())
        {
            Console.WriteLine($"Pozivi od: {contact.FullName} {contact.PhoneNumber}");
            var calls = _phoneBook.Values.ToList();
        
            foreach (var userCalls in calls)
            {
                foreach (var userCall in userCalls)
                {
                    Console.WriteLine($"  {userCall.CallStatus} {userCall.SetUpCallTime}");
                }
            }
        }

       
    }
    public void DisplayAllPhoneCallsWithContact(Contact contact)
    {
        var calls = _phoneBook[contact].ToArray();
        
        if (calls.Length == 0) Console.WriteLine("No phone calls found.");

        foreach (var call in calls)
        {
            Console.WriteLine($" {call.CallStatus} {call.SetUpCallTime}");
        }
    }

    public void AddContactToPhoneBook(Contact newContact)
    {
        var newPhoneCallList = new List<PhoneCall>();
        _phoneBook.Add(newContact, newPhoneCallList);
    }
    
    public Contact? DeleteContactFromPhoneBook()
    {
        var pickedContact = ChooseContactByName();

        _phoneBook.Remove(pickedContact);
        return pickedContact;
    } 
    
    public Contact? EditContactPreference()
    {
        var contactInPhoneBook = ChooseContactByName();
        
        var newPreference = Utils.UserInterface.ChoosePreferenceDisplay();
        
        var contactService = new ContactService(contactInPhoneBook);
        contactService.SetPreference(newPreference);
        
        return contactInPhoneBook;
    }
    
    public Contact? FindContactInPhoneBook(Contact contactToEdit)
    {
        var contact = _phoneBook.Keys.FirstOrDefault(c => c.PhoneNumber == contactToEdit.PhoneNumber);
        if (contact is not null)
        {
            Console.WriteLine("Contact not found");
            return null;
        }
        
        return contact;
    }
    
    public Contact? FindContactInPhoneBookByName(string nameToFind)
    {
        var contact = _phoneBook.Keys.FirstOrDefault(c => c.FullName == nameToFind);
        if (contact is null)
        {
            Console.WriteLine($"Contact with name {nameToFind} is not found");
            return null;
        }
        
        return contact;
    }

    public bool IsPhoneNumberUsed(string phoneNumberToCheck)
    {
        foreach (var contact in _phoneBook.Keys.ToList())
        {
            if (contact.PhoneNumber == phoneNumberToCheck)
            {
                return true;
            }
        }
        return false;
    }

    public Contact ChooseContactByName()
    {
        Contact? contact = null;
        var chooseContactText = "Choose contact by name from displayed phonebook: ";
        DisplayAllContacts();

        do
        {
            var chosenName = UserActions.UserStringInput(chooseContactText);
            contact = FindContactInPhoneBookByName(chosenName);
            
        } while (contact is null);
        
        return contact;
    }

    public void AddPhoneCallToContact(Contact contact, PhoneCall phoneCall)
    {
        if (!_phoneBook.ContainsKey(contact))
            _phoneBook[contact] = new List<PhoneCall>();

        _phoneBook[contact].Add(phoneCall);
    }
    
    public Contact? CreateNewContact()
    {
        var newNameText = "Please enter a name for the contact.";
        var newPhoneNumberText = "Please enter a phone number for the contact.";

        var enteredName = UserActions.UserStringInput(newNameText);

        var enteredPhoneNumber = "";
        var isPhoneNumberUsed = false;
        do
        {
            enteredPhoneNumber = UserActions.UserStringInput(newPhoneNumberText);
            isPhoneNumberUsed = CheckIsPhoneNumberUsed(enteredPhoneNumber);
            if (isPhoneNumberUsed)
            {
                Console.WriteLine("Phone number already used. Try another one.");
            }
        } while (enteredPhoneNumber == string.Empty || isPhoneNumberUsed);
        

        var enteredPreference = Utils.UserInterface.ChoosePreferenceDisplay();
        
        var newContact = new Contact(enteredName.Trim(), enteredPhoneNumber.Trim(), enteredPreference);

        Utils.UserInterface.DisplayContact(newContact);
        
        return newContact;
    }

    public bool CheckIsPhoneNumberUsed(string phoneNumberToCheck)
    {
        if (_phoneBook.Keys.ToList() is []) return false;
        
        return _phoneBook.Keys.ToString().Contains(phoneNumberToCheck);
    }

}