using System.Runtime.Serialization;

namespace BusinessLogic
{
    [DataContract]
    public abstract class Transport
    {
        [DataMember]
        public double speed; //km/h
        [DataMember]
        public double carryingCapacity;//kg
        [DataMember]
        public double timeBeforeAvailability; //h
        public double timeToDeliver(double distance)
        {
            this.timeBeforeAvailability += 2 * distance / this.speed;
            return (distance / this.speed); //h
        }
    }
}