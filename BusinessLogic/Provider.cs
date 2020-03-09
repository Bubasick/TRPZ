using System;
using System.Collections.Generic;
using DataManagement;

namespace BusinessLogic
{
    static public class Provider
    {
        private static MainStore mainStore =
            (MainStore) new Serializator(new XMLSerializator(typeof(MainStore))).Deserialize(
                @"D:\Навчання\TRPZ\Project\DataManagement\MainStore.txt");

       static public List<String> SendStores()
        {
            List<string> storeStringList = new List<string>();
            foreach (var store in mainStore.stores)
            {
               storeStringList.Add(store.ToString()); 
            }

            return storeStringList;
        }
       static public List<String> SendProducts()
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