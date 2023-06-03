namespace GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_Color;
        private eNumOfDoors r_NumOfDoors;
        private const float k_MaxAirPressure = 33f;
        private const int k_NumOfWheels = 5;


        public Car(string i_RegistrationNumber, string i_ModelName, Engine i_Engine, eVehicleType i_VehicleType) : 
            base(i_RegistrationNumber, i_ModelName, i_Engine, k_NumOfWheels, k_MaxAirPressure, i_VehicleType)
        {
        }

        public eCarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return r_NumOfDoors; }
            set { r_NumOfDoors = value; }
        }

        public float MaxAirPressure
        {
            get { return k_MaxAirPressure; }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Car Color: {1}
Number Of Doors: {2}", base.ToString(), m_Color, r_NumOfDoors);
        }
    }
}
