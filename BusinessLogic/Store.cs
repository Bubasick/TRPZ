using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    public class Store
    {
        public double distance;
        public string cityName;

        public Store(double distance,string cityName)
        {
            this.distance = distance;
            this.cityName = cityName;
        }
    }
}