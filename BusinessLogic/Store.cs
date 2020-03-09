using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    public class Store
    {
        [DataMember]
        public double distance;
        [DataMember]
        public string cityName;

        public Store(double distance,string cityName)
        {
            this.distance = distance;
            this.cityName = cityName;
        }
        public Store(double distance)
        {
            this.distance = distance;
        }
        public override string ToString()
        {
            return this.distance + " km";
        }
    }
}