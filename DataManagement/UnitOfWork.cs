using System.Threading.Tasks;
using DataManagement.Entities;
using DataManagement.Interfaces;

namespace DataManagement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryServiceDbContext _context;
        public UnitOfWork(IRepository<Driver> driverRepository, IRepository<Manager> managerRepository, IRepository<Product> productRepository, IRepository<Store> storeRepository, DeliveryServiceDbContext context)
        {
            DriverRepository = driverRepository;
            ManagerRepository = managerRepository;
            ProductRepository = productRepository;
            StoreRepository = storeRepository;
            _context = context;
        }

        public IRepository<Driver> DriverRepository { get; }
        public IRepository<Manager> ManagerRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        public IRepository<Store> StoreRepository { get; }
        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}