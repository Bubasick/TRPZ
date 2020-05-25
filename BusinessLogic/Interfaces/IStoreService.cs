using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IStoreService
    {
        public IEnumerable<StoreDTO> GetStores();
    }
}