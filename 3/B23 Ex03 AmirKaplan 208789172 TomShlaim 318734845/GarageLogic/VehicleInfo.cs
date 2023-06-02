namespace GarageLogic
{
    public class VehicleInfo
    {
        private readonly Vehicle r_Vehicle;
        private readonly VehicleOwner r_VehicleOwner; 
        private eVehicleStatus m_VehicleStatus;
        public VehicleInfo(Vehicle i_Veichle, VehicleOwner i_VehicleOwner, eVehicleStatus i_VehicleType)
        {
            r_Vehicle = i_Veichle;
            r_VehicleOwner = i_VehicleOwner;
            m_VehicleStatus = i_VehicleType;
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
{2}
"
     ,r_VehicleOwner, r_Vehicle, m_VehicleStatus);
        }
    }
}
