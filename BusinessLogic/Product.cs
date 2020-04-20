using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    public class Product : INotifyPropertyChanged
    {
        [DataMember]
        public double Price
        {
            get { return Price; }
            set
            {
                Price = value;
                OnPropertyChanged("Price");
            }
        }
        [DataMember]
        public int Size
        {
            get { return Size; }
            set
            {
                Size = value;
                OnPropertyChanged("Size");
            }
        }
        [DataMember]
        public string Name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string displayProduct()
        {
            return ($"{Name} costs {Price}  weighs {Size} kg \n");
        }
        public override string ToString()
        {
            return ($"{Name} {Price}$  \n"); 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}