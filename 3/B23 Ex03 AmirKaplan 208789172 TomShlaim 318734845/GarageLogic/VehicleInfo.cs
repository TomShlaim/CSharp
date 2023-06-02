namespace GarageLogic
{
    internal class VehicleInfo
    {
        private readonly Vehicle r_Veichle;
        private readonly VehicleOwner r_VehicleOwner; 
        private eVehicleStatus m_VehicleStatus = eVehicleStatus;
        
        public VehicleInfo(Vehicle i_Veichle, VehicleOwner i_VechileOwner)
        {

        }
        public enum eVehicleStatus  // eNum defition can later be refactored to a stand-alone file. not sure what's better
        {
            InRepair,
            Repaired,
            Paid
        }
        public override string ToString()
        {
            return string.Format(
@"Veichle information: 
{0}
{1} 
{2}
"
     ,r_VehicleOwner, r_Veichle, m_VehicleStatus);
        }
    }
}
