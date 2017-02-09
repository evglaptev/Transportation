using Server.Entities;

namespace Server.Interfaces
{
    internal interface IManagers : IPersons
    {
        int getManagerForOrderId(int order);
    }
}