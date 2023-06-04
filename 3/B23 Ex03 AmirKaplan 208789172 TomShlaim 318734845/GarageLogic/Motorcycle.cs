namespace GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const float k_MaxAirPressure = 31f;
        private const int k_NumOfWheels = 2;

        public Motorcycle(string i_RegistrationNumber, string i_ModelName, Engine i_Engine, string i_WheelsManufacturer, eVehicleType i_VehicleType)
            : base(i_RegistrationNumber, i_ModelName, i_Engine, i_WheelsManufacturer, k_NumOfWheels, k_MaxAirPressure, i_VehicleType)
        {
        }

        public  eLicenseType LicenseType
        { 
            get { return m_LicenseType; }
            set { m_LicenseType = value; } 
        }

        public int EngineVolume 
        { 
            get { return m_EngineVolume; } 
            set { m_EngineVolume = value; }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
License Type: {1}
Engine Volume: {2} cc
", base.ToString(), m_LicenseType, m_EngineVolume);
        }
    }
}
