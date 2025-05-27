namespace PhoneBook.Utils;

public static class UserActions
{
    public static int UserNumberInput()
    {
        var inputText = "Please choose an number from the menu provided: ";
        Console.WriteLine(inputText);
        
        var userInput = Console.ReadLine();
        var parsedInput = int.TryParse(userInput, out var userNumber);
        return parsedInput ? userNumber : 0;
    }
    
    public static string UserStringInput(string? inputText)
    {
        var userInput = "";

        if (inputText is not null)
        {
            Console.WriteLine(inputText);
        }
        
        do
        {
            userInput = Console.ReadLine();
            if (userInput is "" || userInput is null)
            {
                Console.WriteLine("Input cannot be empty.");
            }
            else if (userInput.Length > 20 || userInput.Length <= 1)
            {
                Console.WriteLine("Input cannot be more than 20 characters or less than 2.");
            }
            
        } while (userInput is "" || userInput is null);
        
        return userInput;
    }
    
}