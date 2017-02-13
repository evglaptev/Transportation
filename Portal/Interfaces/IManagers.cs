using System.Collections.Generic;
using Portal.Entities;

namespace Portal.Interfaces
{
    internal interface IManagers:IPersons
    {
        int getManagerForOrderId(int order);
    }
}