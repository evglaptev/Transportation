using Portal.Entities;
using System.Collections.Generic;

namespace Portal.Interfaces
{
    internal interface IDrivers : IPersons
    {
        int getDriverForOrderId(int key);
    }
}