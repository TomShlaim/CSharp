namespace GarageLogic
{
    public class VehicleOwner
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;

        public VehicleOwner(string i_Name, string i_Phone) 
        { 
            r_Name = i_Name;
            r_PhoneNumber = i_Phone;
        }
        public string Name
        {
            get { return r_Name; }
        }
        public string PhoneNumber
        {
            get { return r_PhoneNumber; }
        }
        public override string ToString()
        {
            return string.Format(
@"
Owner :
=======
Name : {0}
Phone number: {1}
"
     , r_Name, r_PhoneNumber);
        }
    }
}
