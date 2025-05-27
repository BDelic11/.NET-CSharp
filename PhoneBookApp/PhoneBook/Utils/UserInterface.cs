using PhoneBook.Entities;
using PhoneBook.Enums;

namespace PhoneBook.Utils;

public static class UserInterface
{
    
    public static Preference ChoosePreferenceDisplay()
    {
        var preferences = Enum.GetValues(typeof(Preference)).Cast<Preference>().ToList();
        int userInput = 0;

        do
        {
            Console.WriteLine("\n \nChoose one of contact preferences: ");
            
            for (int i = 0; i < preferences.Count; i++)
            {
                Console.WriteLine($" {i}. {preferences[i]}");
            }
            
            Console.Write("Enter the number of your choice: ");
            userInput = UserActions.UserNumberInput();
            
        } while (userInput < 0 || userInput >= preferences.Count);
        
        return preferences[userInput];
    }
    
    public static void DisplayContact(Contact contact)
    {
        Console.WriteLine($"Contact: {contact.FullName} | Phone: {contact.PhoneNumber} | Preference: {contact.Preference} ");
    }
    
    
}