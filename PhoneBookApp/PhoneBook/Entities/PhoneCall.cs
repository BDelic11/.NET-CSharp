using PhoneBook.Enums;

namespace PhoneBook.Entities;

public class PhoneCall
{
    public PhoneCall(DateTime setUpCallTime,  CallStatus callStatus)
    {
        SetUpCallTime = setUpCallTime;
        CallStatus = callStatus;
    }
    public DateTime SetUpCallTime { get; set;}

    public CallStatus? CallStatus { get; set; } = null;
    
}