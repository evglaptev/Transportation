namespace Server.Interfaces
{
    internal interface IDrivers : IPersons
    {
        int getDriverForOrderId(int key);
    }
}