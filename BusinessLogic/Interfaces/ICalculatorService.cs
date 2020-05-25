using System;
using BusinessLogic.DTO;
using DataManagement.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ICalculatorService
    {
        TimeSpan CalculateTime(ProductDTO product, StoreDTO store);
    }
}