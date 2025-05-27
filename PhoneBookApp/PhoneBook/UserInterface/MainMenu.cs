using PhoneBook.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Utils;

namespace PhoneBook.UserInterface;

public class MainMenuHandler
{
    private readonly IPhoneBookService _phoneBookService;
    private readonly ISubMenuHandler _subMenuHandler;

    public MainMenuHandler(IPhoneBookService phoneBookService,ISubMenuHandler subMenuHandler)
    {
        _phoneBookService = phoneBookService;
        _subMenuHandler = subMenuHandler;
    }

    public static void MenuDisplay()
    {
        Console.WriteLine("\n \nThis is your menu!" +
                          "\n     1. Display all contacts in phonebook" +
                          "\n     2. Add new contact to phonebook" +
                          "\n     3. Delete contact from phonebook" +
                          "\n     4. Edit contact" +
                          "\n     5. Manage contacts - open SubMenu" +
                          "\n     6. Display all phone calls" +
                          "\n     7. Exit" 
        );
    }
    
    public void MenuSwitchDisplay()
    {
        var userInput = 0;
        do
        {
            MenuDisplay();
            userInput = UserActions.UserNumberInput();
            switch (userInput)
            {
                case 1:
                    _phoneBookService.DisplayAllContacts();
                    break;
                case 2:
                    var newContact = _phoneBookService.CreateNewContact();
                    if (newContact is not null)
                        _phoneBookService.AddContactToPhoneBook(newContact);
                    break;
                case 3:
                    var deletedContact = _phoneBookService.DeleteContactFromPhoneBook();
                    if (deletedContact is not null)
                        Console.WriteLine($"Obrisali ste kontakt: {deletedContact.FullName}.");
                    break;
                case 4:
                    var editedContact = _phoneBookService.EditContactPreference();
                    if (editedContact is not null)
                        Console.WriteLine($"Izmijenili ste {editedContact.FullName} preferencu u {editedContact.Preference}");
                    break;
                case 5:
                    var contact = _phoneBookService.ChooseContactByName();
                    _subMenuHandler.SubMenuSwitchDisplay(contact);
                    break;
                case 6:
                    _phoneBookService.DisplayAllPhoneCalls();
                    break;
                case 7:
                    Console.WriteLine("You exited the program.");
                    break;
                default:
                    Console.WriteLine("Please enter one of the numbers in menu provided and try again.");
                    break;
                    
            }

        } while (userInput is not 7);
        
    }

}