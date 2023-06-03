using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterial;
        private bool m_IsRefrigeratedTransport;
        private float m_CargoVolume;
        private const int k_NumOfWheels = 14;
        private const float k_MaxAirPressure = 26f;

        public Truck(string i_RegistrationNumber, string i_ModelName, Engine i_Engine) 
            : base(i_RegistrationNumber, i_ModelName, i_Engine, k_NumOfWheels, k_MaxAirPressure)
        {

        }

        public float CargoVolume
        { 
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public bool IsRefrigeratedTransport
        {
            get { return m_IsRefrigeratedTransport; }
            set { m_IsRefrigeratedTransport = value; }
        }

        public bool IsCarryingDangerousMaterial
        {
            get { return m_IsCarryingDangerousMaterial; }
            set { m_IsCarryingDangerousMaterial = value; }
        }

        public override string ToString()
        {
            string isCarryingDangerousMaterialString = m_IsCarryingDangerousMaterial ? "Yes" : "No";
            string isRefrigeratedTransportString = m_IsRefrigeratedTransport ? "Yes" : "No";

            return string.Format(
@"{0}
Cargo Volume: {1}
Carrying Dangerous Material: {2}
Refrigerated Transport: {3}", base.ToString(), m_CargoVolume, isCarryingDangerousMaterialString, isRefrigeratedTransportString);
        }

    }
}
