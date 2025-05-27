using PhoneBook.Enums;
using PhoneBook.Utils;

namespace PhoneBook.Entities;

public class Contact
{
    public Contact(string fullName, string phoneNumber, Preference preference)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Preference = preference;
    }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Preference Preference { get; set; } = Preference.Normal;

  
}