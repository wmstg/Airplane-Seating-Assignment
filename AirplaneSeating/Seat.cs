using System;
using System.Runtime.Serialization;

namespace AirplaneSeating
{
    [Serializable()]
    class Seat : ISerializable
    {
        public enum CabinClass
        {
            First,
            Economy
        }

        // Seat Identifer example; 2A
        private String seatId;
        public String SeatId
        {
            get { return seatId; }
        }

        private CabinClass cabin;
        public String Cabin
        {
            get
            {
                switch (cabin)
                {
                    case CabinClass.First:
                        return "First";
                    case CabinClass.Economy:
                    default:
                        return "Economy";
                }
            }

        }

        private String location;
        public String Location
        {
            get { return location; }
        }

        private Passenger passenger;
        public String Passenger
        {
            get { return passenger.Name; }
            set { passenger.Name = value; }
        }

        private bool reserved = false;
        public bool Reserved
        {
            get { return reserved; }
            set { reserved = value; }
        }

        public Seat(String seatId, CabinClass cabinClass, String location)
        {
            passenger = new Passenger();
            this.seatId = seatId;
            cabin = cabinClass;
            this.location = location;
        }

        /// <summary>
        /// Deserializes and assigns the values to the apporpriate fields
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public Seat(SerializationInfo info, StreamingContext ctxt)
        {
            seatId = (String)info.GetValue("SeatId", typeof(string));
            cabin = (CabinClass)info.GetValue("Cabin", typeof(CabinClass));
            location = (String)info.GetValue("Location", typeof(string));
            passenger = new Passenger((String)info.GetValue("PassengerName", typeof(string)));
            reserved = (bool)info.GetValue("Reserved", typeof(bool));
        }

        /// <summary>
        /// Serializes the seat data
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SeatId", seatId);
            info.AddValue("Cabin", cabin);
            info.AddValue("Location", location);
            info.AddValue("PassengerName", Passenger);
            info.AddValue("Reserved", reserved);
        }
    }
}
