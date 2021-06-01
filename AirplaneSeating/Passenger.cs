using System;

namespace AirplaneSeating
{
    class Passenger
    {
        private String name = "";
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Passenger(String name)
        {
            this.name = name;
        }

        public Passenger()
        {

        }
    }
}
