namespace GarageLogic
{
    public class GarageVehicleInfo
    {
        private readonly Vehicle r_Vehicle;
        private readonly VehicleOwner r_VehicleOwner; 
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        public GarageVehicleInfo(Vehicle i_Veichle, VehicleOwner i_VehicleOwner)
        {
            r_Vehicle = i_Veichle;
            r_VehicleOwner = i_VehicleOwner;
        }
        public Vehicle Vehicle 
        {
            get { return r_Vehicle; } 
        }
        public VehicleOwner VehicleOwner
        {
            get { return r_VehicleOwner; }
        }
        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }
        public override string ToString()
        {
            return string.Format(
@"Veichle information: 
======================
{0}
{1} 
Current status in garage : {2}
"
     ,r_Vehicle, r_VehicleOwner, m_VehicleStatus);
        }
    }
}
