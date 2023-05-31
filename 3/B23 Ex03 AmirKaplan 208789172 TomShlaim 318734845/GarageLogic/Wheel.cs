using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(string i_Manufacturer, float i_MaxAirPressure) : this(i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
        }

        public void Inflate(float i_AirPressure)
        {
            // Validation (that max pressure was not exceeded) should be entered here (?)
            m_CurrentAirPressure += i_AirPressure;
        }

        public string Manufacturer
        {
            get { return r_Manufacturer; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                // Validation here (?)
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public override string ToString()
        {
            return string.Format(
@"Manufacturer: {0}
Current Air Pressure: {1} PSI
Maximum Air Pressure: {2} PSI"
, r_Manufacturer, m_CurrentAirPressure, r_MaxAirPressure);
        }

    }


}
