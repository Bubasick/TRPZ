using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataManagement.Interfaces;
using System;
using DataManagement;

namespace BusinessLogic.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        readonly IDriverService _driverService;
        readonly IManagerService _managerService;
        public CalculatorService(IUnitOfWork unitOfWork, IMapper mapper, IDriverService driverService, IManagerService managerService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _driverService = driverService;
            _managerService = managerService;
        }

        public TimeSpan CalculateTime(ProductDTO product, StoreDTO store)
        {
           var driver = _driverService.GetTheLeastBusyDriver();
           var manager = _managerService.GetTheLeastBusyManager();
           TimeSpan timeToDeliver = _driverService.HowMuchTimeToDeliver(store, driver) +
                                    _managerService.HowMuchTimeToCreateOrder(product, manager);
           //Not complete. There are need to update the driver.DateOfAvailability and manager.DateOfAvailability to the DB
          
           using (var db = new DeliveryServiceDbContext())
           {

               if (driver.DateOfAvailability < DateTime.Now)
                   driver.DateOfAvailability = DateTime.Now + _driverService.HowMuchTimeToDeliver(store, driver) * 2;
               else 
                   driver.DateOfAvailability += _driverService.HowMuchTimeToDeliver(store, driver) * 2;
                
               if (manager.DateOfAvailability < DateTime.Now)
                   manager.DateOfAvailability = DateTime.Now + _managerService.HowMuchTimeToCreateOrder(product, manager);
               
               else 
                   manager.DateOfAvailability += _managerService.HowMuchTimeToCreateOrder(product, manager);
               db.SaveChanges();
           }
            return timeToDeliver;
        }
    }
}