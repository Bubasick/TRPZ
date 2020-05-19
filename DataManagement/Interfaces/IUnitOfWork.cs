using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataManagement.Entities;

namespace DataManagement.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Driver> DriverRepository { get; }
        IRepository<Manager> ManagerRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Store> StoreRepository { get; }
        Task Save();
    }
}
