using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataManagement.Interfaces;
using System;
using System.Linq;

namespace BusinessLogic.Services
{
    public class ManagerService:IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManagerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ManagerDTO GetTheLeastBusyManager()
        {
            var manager = _unitOfWork.ManagerRepository.GetAll().OrderBy(x => x.DateOfAvailability).FirstOrDefault();
            return _mapper.Map<ManagerDTO>(manager);
        }

        public TimeSpan HowMuchTimeToCreateOrder(ProductDTO product, ManagerDTO manager)
        {
            TimeSpan time = TimeSpan.FromMinutes(product.Name.Length / manager.TypingSpeed);
            return time;
        }
    }
}