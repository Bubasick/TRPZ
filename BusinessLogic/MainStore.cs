using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    [KnownType(typeof(Driver))]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Truck))]
    [KnownType(typeof(Motorbike))]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Manager))]
    public class MainStore
    {
        [DataMember]
        public List<Driver> drivers = new List<Driver>();
        [DataMember]
        public List<Store> stores = new List<Store>();
        [DataMember]
        public List<Car> cars = new List<Car>();
        [DataMember]
        public List<Truck> trucks = new List<Truck>();
        [DataMember]
        public List<Motorbike> motorbikes = new List<Motorbike>();
        [DataMember]
        public List<Product> products = new List<Product>();
        [DataMember]
        public List<Manager> managers = new List<Manager>();

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException();
            products.Add(product);
        }
        public List<string> displayProducts()
        {
            List<string> productList = new List<string>();
            foreach (Product product in products)
            {
                productList.Add(product.displayProduct());
            }

            return productList;

        }

    }
}