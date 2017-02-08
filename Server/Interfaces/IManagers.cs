using Server.Entities;

namespace Server
{
    internal interface IManagers : IPersons
    {
        int getManagerForOrderId(int order);
    }
}