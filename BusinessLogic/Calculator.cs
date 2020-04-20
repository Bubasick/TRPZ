using System;

namespace BusinessLogic
{
    public static class Calculator
    {
        static MainStore mainStore = new MainStore();

        static public void SetStore(ref MainStore data)
        {
            mainStore = data;
        }
        static public Manager chooseManager()
        {
            mainStore.managers.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
            return mainStore.managers[0];
        }
        static public Transport chooseTransportType(Product product)
        {
            if (product.Size < 20)
            {
                mainStore.motorbikes.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
                return mainStore.motorbikes[0];
            }
            if (20 <= product.Size && product.Size < 200)
            {
                mainStore.cars.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
                return mainStore.cars[0];
            }
            if (200 <= product.Size && product.Size < 1500)
            {
                mainStore.trucks.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
                return mainStore.trucks[0];
            }
            else return null;
        }
        static public Driver chooseDriver(Transport transport)
        {
            mainStore.drivers.Sort((x, y) => x.timeBeforeAvailability.CompareTo(y.timeBeforeAvailability));
            foreach (Driver driver in mainStore.drivers)
            {
                if (driver.carPermit && transport.GetType().Name == "Car")
                {
                    driver.currentTransport = transport;
                    return driver;
                }
                if (driver.motorbikePermit && transport.GetType().Name == "Motorbike")
                {
                    driver.currentTransport = transport;
                    return driver;
                }
                if (driver.truckPermit && transport.GetType().Name == "Truck")
                {
                    driver.currentTransport = transport;
                    return driver;
                }
            }
            return null;
        }
        static public double timeToDeliver(string name, int id)
        {
            double time = 0;
            double distance = mainStore.stores[id].Distance;
            Product product = mainStore.products.Find(i => i.Name == name); //search for a Product object by its name
            Manager manager = chooseManager();
            Driver driver = chooseDriver(chooseTransportType(product));
            // System.Console.WriteLine(manager.timeNeededToPerformTask(product));

            time = manager.timeNeededToPerformTask(product) + driver.currentTransport.timeToDeliver(distance) + Math.Max(driver.timeBeforeAvailability, driver.currentTransport.timeBeforeAvailability);
            driver.timeBeforeAvailability += 2 * driver.currentTransport.timeToDeliver(distance);
            manager.timeBeforeAvailability += manager.timeNeededToPerformTask(product);

            return Math.Round(time, 2);

        }
        static public double timeToDeliver(Product product, Store store)
        {
            double time = 0;
            double distance = store.Distance;
            Manager manager = chooseManager();
            Driver driver = chooseDriver(chooseTransportType(product));
            // System.Console.WriteLine(manager.timeNeededToPerformTask(product));

            time = manager.timeNeededToPerformTask(product) + driver.currentTransport.timeToDeliver(distance) + Math.Max(driver.timeBeforeAvailability, driver.currentTransport.timeBeforeAvailability);
            driver.timeBeforeAvailability += 2 * driver.currentTransport.timeToDeliver(distance);
            manager.timeBeforeAvailability += manager.timeNeededToPerformTask(product);

            return Math.Round(time, 2);

        }
    }
}