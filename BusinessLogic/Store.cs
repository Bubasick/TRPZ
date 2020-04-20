using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    public class Store : INotifyPropertyChanged
    {
        [DataMember]
        public double Distance
        {
            get { return Distance; }
            set
            {
                Distance = value;
                OnPropertyChanged("Distance");
            }
        }

        [DataMember]
        public string CityName
        {
            get { return CityName; }
            set
            {
                CityName = value;
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