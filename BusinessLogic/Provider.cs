using System;
using System.Collections.Generic;
using DataManagement;

namespace BusinessLogic
{
    public  class Provider 
    {
        private MainStore mainStore;
        private IGetData _getData;
        public Provider(IGetData getData)
        {
            _getData = getData;
            mainStore = _getData.GetObject(typeof(MainStore));
        }
        public List<Store> SendStores()
        {
            return mainStore.stores;
        }
         public List<Product> SendProducts()
        {
            return mainStore.products;
        }

         public string SendDeliveryTime(Product product, Store store)
         {
             Calculator.SetStore(ref mainStore);
             TimeSpan time = TimeSpan.FromHours(Calculator.timeToDeliver(product, store));
             return time.Days + " days " + time.Hours + " hours " + time.Minutes + " minutes "; 
         }
       
    }
}