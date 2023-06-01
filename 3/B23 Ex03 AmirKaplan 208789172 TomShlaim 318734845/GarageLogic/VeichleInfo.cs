using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class VeichleInfo
    {

        
        // I think the 'toString()' method of this class should use other classes 'toString()' methods , one after the other."

        private readonly VeichleOwner r_VehicleOwner; // Should the owner of the vehicle be a field in this class or in 'Veichle' class? not sure
        private readonly Veichle r_Name;
        private eVehicleStatus m_VehicleStatus;
        
       
        public enum eVehicleStatus  // eNum defition can later be refactored to a stand-alone file. not sure what's better
        {
            InRepair,
            Repaired,
            Paid
        }
    }
}
