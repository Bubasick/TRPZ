using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using System;
using System.Linq;
using AutoMapper;
using DataManagement.Interfaces;

namespace BusinessLogic.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public DriverDTO GetTheLeastBusyDriver()
        {
            var driver = _unitOfWork.DriverRepository.GetAll().OrderBy(x => x.DateOfAvailability).FirstOrDefault();
            return _mapper.Map<DriverDTO>(driver);
        }

        public TimeSpan HowMuchTimeToDeliver(StoreDTO store, DriverDTO driver)
        {
            TimeSpan time = TimeSpan.FromHours(store.DistanceInKm / driver.SpeedOfCarInKm);
            return time;
        }

        
    }
}