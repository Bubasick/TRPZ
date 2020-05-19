using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using BusinessLogic;

namespace Presentation
{
    class StoreAndProductViewModel : INotifyPropertyChanged
    {
        private Store selectedStore;
        private Product selectedProduct;

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           MessageBox.Show("Your order will be delivered in ");
                       }));
            }
        }

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
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public StoreAndProductViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}