using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UserInterface
{
    public class Order : INotifyPropertyChanged
    {
        private string title;
        private string company;
        private int price;
        List<Product> products = new List<Product>();
        private List<Store> stores = new List<Store>();

        public Order()
        {
            Provider provider = new Provider(new GetData());
            List<Product> products = provider.SendProducts();
            List<Store> stores = provider.SendStores();
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}