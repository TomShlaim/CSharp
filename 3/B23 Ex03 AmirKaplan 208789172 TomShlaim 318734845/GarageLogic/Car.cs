﻿namespace GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_Color;
        private eNumOfDoors r_NumOfDoors;
        private const float k_MaxAirPressure = 33f;
        private const int k_NumOfWheels = 5;


        public Car(string i_RegistrationNumber, string i_ModelName, Engine i_Engine, string i_WheelsManufacturer, eVehicleType i_VehicleType)
            : base(i_RegistrationNumber, i_ModelName, i_Engine, i_WheelsManufacturer, k_NumOfWheels, k_MaxAirPressure, i_VehicleType)
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
        public override string ToString()
        {
            return string.Format(
@"{0}
Car Color: {1}
Number Of Doors: {2}
", base.ToString(), m_Color, r_NumOfDoors);
        }
    }
}
