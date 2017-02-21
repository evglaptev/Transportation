using Portal.Entities;

namespace Portal.Interfaces
{
    internal interface IClients : IPersons
    {
        Client getByPhoneNumber(string name);
    }
}