using PhoneBook.Entities;
using PhoneBook.Enums;
using PhoneBook.Interfaces;

namespace PhoneBook.Services;

public class ContactService: IContactService
{
    private readonly Contact _contact;

    public ContactService(Contact contact)
    {
        _contact = contact;
    }

    public void SetPreference(Preference preference)
    {
       _contact.Preference = preference;
    }

}