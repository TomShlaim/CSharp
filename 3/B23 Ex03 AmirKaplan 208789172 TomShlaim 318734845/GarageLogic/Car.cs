using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_Color;
        private readonly eNumOfDoors r_NumOfDoors;
        private const float k_MaxAirPressure = 33f;
        private const int k_NumOfWheels = 5;


        public Car(string i_RegistrationNumber, string i_ModelName, Engine i_Engine) : base(i_RegistrationNumber, i_ModelName, i_Engine)
        {
        }

        public Car(string i_RegistrationNumber, string i_ModelName, Engine i_Engine, eCarColor i_Color, eNumOfDoors i_NumOfDoors) 
            : base(i_RegistrationNumber, i_ModelName, i_Engine)
        {
            m_Color = i_Color;
            r_NumOfDoors = i_NumOfDoors;
        }

        public eCarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return r_NumOfDoors; }
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
