using PhoneBook.Entities;
using PhoneBook.Enums;

namespace PhoneBook.Interfaces;

public interface IPhoneCallService
{
    public PhoneCall? CreateNewPhoneCall(Contact contact);


}