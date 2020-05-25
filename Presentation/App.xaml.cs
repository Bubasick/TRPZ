using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using BusinessLogic.AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataManagement;
using DataManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
            private IServiceProvider serviceProvider;
            public App()
            {
                var connection = "Server = localhost; Database = DeliveryDB; Uid = root; Pwd = 11111111;";
                var services = new ServiceCollection().AddDbContext<DeliveryServiceDbContext>(options => options.UseMySql(connection));
                ConfigureServices(services);
                serviceProvider = services.BuildServiceProvider();
            }
            private void ConfigureServices(IServiceCollection services)
            {
                services.BindMapper();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddTransient<IDriverService, DriverService>();
                services.AddTransient<IManagerService, ManagerService>();
                services.AddTransient<ICalculatorService, CalculatorService>();
                services.AddTransient<IStoreService, StoreService>();
                services.AddTransient<IProductService, ProductService>();
        }
            protected override void OnStartup(StartupEventArgs e)
            {
                var StoreAndProductViewModel = serviceProvider.GetService<StoreAndProductViewModel>();
                MainWindow = new MainWindow { DataContext = StoreAndProductViewModel };
                MainWindow.Show();
            }
        }
    }
