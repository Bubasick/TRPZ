using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    public class Store : INotifyPropertyChanged
    {
        [DataMember] 
        private double distance;
        public double Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        [DataMember] 
        private string cityName;
        public string CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;
                OnPropertyChanged("CityName");
            }
        }

        public Store(double distance,string cityName)
        {
            this.Distance = distance;
            this.CityName = cityName;
        }
        public Store(double distance)
        {
            this.Distance = distance;
        }
        public override string ToString()
        {
            return  this.Distance + " km";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}