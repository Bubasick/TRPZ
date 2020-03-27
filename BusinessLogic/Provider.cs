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
        public List<String> SendStores()
        {
            List<string> storeStringList = new List<string>();
            foreach (var store in mainStore.stores)
            {
               storeStringList.Add(store.ToString()); 
            }

            return storeStringList;
        }
         public List<String> SendProducts()
        {
            List<string> productStringList = new List<string>();
            foreach (var product in mainStore.products)
            {
                productStringList.Add(product.ToString());
            }

            return productStringList;
        }

       
    }
}