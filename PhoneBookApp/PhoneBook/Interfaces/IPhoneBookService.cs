using PhoneBook.Entities;

namespace PhoneBook.Interfaces;

public interface IPhoneBookService
{
    void DisplayAllContacts();
    void DisplayAllPhoneCalls();
    void DisplayAllPhoneCallsWithContact(Contact contact);
    void AddContactToPhoneBook(Contact newContact);
    Contact? DeleteContactFromPhoneBook();
    Contact? EditContactPreference();
    Contact? FindContactInPhoneBook(Contact contactToEdit);
    Contact? FindContactInPhoneBookByName(string name);
    bool IsPhoneNumberUsed(string phoneNumber);
    Contact ChooseContactByName();
    void AddPhoneCallToContact(Contact contact, PhoneCall phoneCall);
    public Contact? CreateNewContact();
    public bool CheckIsPhoneNumberUsed(string phoneNumberToCheck);

}