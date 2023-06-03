namespace GarageLogic
{
    public class VehicleOwner
    {
        private readonly string r_Name;
        private readonly string r_Phone;

        public VehicleOwner(string i_Name, string i_Phone) 
        { 
            r_Name = i_Name;
            r_Phone = i_Phone;
        }
        public string Name
        {
            get { return r_Name; }
        }
        public string Phone
        {
            get { return r_Phone; }
        }
        public override string ToString()
        {
            return string.Format(
@"
Owner :
=======
Name : {0}
Phone: {1}
"
     , r_Name, r_Phone);
        }
    }
}
