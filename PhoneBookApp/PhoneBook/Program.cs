using PhoneBook.Interfaces;
using PhoneBook.Services;
using PhoneBook.UserInterface;
using PhoneBook.Utils;
using Contact = PhoneBook.Entities.Contact;
using PhoneCall = PhoneBook.Entities.PhoneCall;

namespace PhoneBook;

class Program
{
    static void Main(string[] args)
    {
        var phoneBook = new Dictionary<Contact, List<PhoneCall>>();
        
        IPhoneBookService phoneBookService = new PhoneBookService(phoneBook);
        IPhoneCallService phoneCallService = new PhoneCallService(phoneBook);
        
        ISubMenuHandler subMenuHandler = new SubMenuHandler(phoneBookService, phoneCallService);
        var mainMenuHandler = new MainMenuHandler(phoneBookService, subMenuHandler);
        
        mainMenuHandler.MenuSwitchDisplay();
        
    }

   
}