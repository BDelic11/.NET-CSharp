using PhoneBook.Entities;
using PhoneBook.Enums;
using PhoneBook.Interfaces;

namespace PhoneBook.Services;

public class PhoneCallService : IPhoneCallService
{
    private readonly Dictionary<Contact,List<PhoneCall>> _phoneBook;
    
    public PhoneCallService(Dictionary<Contact,List<PhoneCall>> phoneBook)
    {
        _phoneBook = phoneBook;
    }

    public PhoneCall? CreateNewPhoneCall(Contact contact)
    {
        if (contact.Preference == Preference.Blocked)
        {
            return null;
        }

        var now = DateTime.Now;
        var randomStatus = RandomCallStatus();

        var newPhoneCall = new PhoneCall(now, randomStatus); 
        
        return newPhoneCall;
        
    }

    private CallStatus RandomCallStatus()
    {
        var values = Enum.GetValues(typeof(CallStatus));

        Random random = new Random();
        int index = random.Next(values.Length); 

        var status = (CallStatus)values.GetValue(index);
        
        if (status is Enums.CallStatus.InProgress)
        {
            int durationOfCall = random.Next(1,20);
            Console.WriteLine("Call status is in progress...");
            Thread.Sleep(durationOfCall);
            Console.WriteLine("Call is ended.");
            return Enums.CallStatus.Completed;
        }
        else if (status is Enums.CallStatus.Completed)
        {
            Console.WriteLine("Call is completed.");
        }
        else if (status is Enums.CallStatus.Missed)
        {
            Console.WriteLine("Missed call.");

        }
      

        return status;
    }
}