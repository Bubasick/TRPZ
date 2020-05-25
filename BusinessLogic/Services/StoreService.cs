using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataManagement.Interfaces;

namespace BusinessLogic.Services
{
    public class StoreService: IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<StoreDTO> GetStores()
        {
            var store = _unitOfWork.StoreRepository.GetAll();
            return _mapper.Map<IEnumerable<StoreDTO>>(store);
        }
    }
}