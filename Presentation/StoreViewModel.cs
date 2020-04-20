using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BusinessLogic;

namespace Presentation
{
    class StoreViewModel :INotifyPropertyChanged
    {
        private Store selectedStore;
        private Product selectedProduct;

        public ObservableCollection<Store> Stores { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public Store SelectedStore
        {
            get { return selectedStore; }
            set
            {
                selectedStore = value;
                OnPropertyChanged("SelectedStore");
            }
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct= value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public StoreViewModel()
        {
            Provider provider = new Provider(new GetData()); 
            Products = new ObservableCollection<Product>(provider.SendProducts());
            Stores = new ObservableCollection<Store>(provider.SendStores());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
