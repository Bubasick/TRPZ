using System;
using BusinessLogic.DTO;
using DataManagement.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IManagerService
    {
        ManagerDTO GetTheLeastBusyManager();
        TimeSpan HowMuchTimeToCreateOrder(ProductDTO product, ManagerDTO manager);
    }
}