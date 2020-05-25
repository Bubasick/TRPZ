using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataManagement.Interfaces;

namespace BusinessLogic.Services
{
    public class ProductService :IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}