using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Motorcycle : Vehicle
    {

        private const float k_MaxAirPressure = 31f;
        private const int k_NumOfWheels = 2;

        public Motorcycle(string i_RegistrationNumber, string i_ModelName, Engine i_Engine) : base(i_RegistrationNumber, i_ModelName, i_Engine, k_NumOfWheels, k_MaxAirPressure)
        {

        }
    }
}
