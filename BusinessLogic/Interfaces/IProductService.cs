using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductDTO> GetProducts();
    }
}