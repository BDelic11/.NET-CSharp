using PhoneBook.Entities;
using PhoneBook.Interfaces;
using PhoneBook.Utils;

namespace PhoneBook.UserInterface;

public class SubMenuHandler: ISubMenuHandler
{
    private readonly IPhoneBookService _phoneBookService;
    private readonly IPhoneCallService _phoneCallService;

    public SubMenuHandler(IPhoneBookService phoneBookService, IPhoneCallService phoneCallService)
    {
        _phoneBookService = phoneBookService;
        _phoneCallService = phoneCallService;
    }

    private static void SubMenuDisplay()
    {
        Console.WriteLine("\n \nThis is your SubMenu for contact management!" +
                          "\n     1. List of phone calls with contact (newest to oldest)" +
                          "\n     2. Create a new phone call" +
                          "\n     3. Exit submenu"
        );
    }
    
    public void SubMenuSwitchDisplay(Contact contact)
    {
        var userInput = 0;
        do
        {
            SubMenuDisplay();
            userInput = UserActions.UserNumberInput();
            switch (userInput)
            {
                case 1:
                    _phoneBookService.DisplayAllPhoneCallsWithContact(contact);
                    break;
                case 2:
                    var newPhoneCall = _phoneCallService.CreateNewPhoneCall(contact);
                    if (newPhoneCall is not null)
                        _phoneBookService.AddPhoneCallToContact(contact, newPhoneCall);
                    else
                        Console.WriteLine("Not able to create call to Blocked user");
                    break;
                case 3:
                    Console.WriteLine("Back to main menu.");
                    break;
                default:
                    Console.WriteLine("Please enter one of the numbers in menu provided and try again.");
                    break;
                    
            }

        } while (userInput is not 3);
        
    }
}