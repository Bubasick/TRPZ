using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using BusinessLogic;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace Presentation
{
    class StoreAndProductViewModel : INotifyPropertyChanged
    {
        private readonly IStoreService storeService;
        private readonly IProductService productService;
        private StoreDTO selectedStore;
        private ProductDTO selectedProduct;
        public ICalculatorService _calculator;
        private RelayCommand addCommand;

        public StoreAndProductViewModel(ICalculatorService calculator, IProductService ProductService, IStoreService StoreService)
        {
            _calculator = calculator;
            storeService = StoreService;
            productService = ProductService;
            Products = new ObservableCollection<ProductDTO>(productService.GetProducts());
            Stores = new ObservableCollection<StoreDTO>(storeService.GetStores());

        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           MessageBox.Show("Your order will be delivered in " + _calculator.CalculateTime(selectedProduct,selectedStore).ToString());
                       }));
            }
        }

        public ObservableCollection<StoreDTO> Stores { get; set; }
        public ObservableCollection<ProductDTO> Products { get; set; }

        public StoreDTO SelectedStore
        {
            get { return selectedStore; }
            set
            {
                selectedStore = value;
                OnPropertyChanged("SelectedStore");
            }
        }

        public ProductDTO SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}