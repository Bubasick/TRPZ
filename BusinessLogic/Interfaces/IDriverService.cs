using System;
using BusinessLogic.DTO;
using Microsoft.VisualBasic;

namespace BusinessLogic.Interfaces
{
    public interface IDriverService
    {
        DriverDTO GetTheLeastBusyDriver();
        TimeSpan HowMuchTimeToDeliver(StoreDTO store, DriverDTO driver);
    }
}