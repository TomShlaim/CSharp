using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Engine
    {
        private float m_EnergyPercentage;
        private static readonly Dictionary<eVehicleType, float> r_EnergyCapacityDict = new Dictionary<eVehicleType, float>
        {
            { eVehicleType.ElectricCar, 5.2f },
            { eVehicleType.ElectricMotorcycle, 2.6f },
            { eVehicleType.FuelCar, 46f },
            { eVehicleType.FuelMotorcycle, 6.4f },
            { eVehicleType.Truck, 135f }
        };

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
        }

        public void SetEnergyPercentage(float i_CurrentEnergy, float i_MaxEnergyCapacity)
        {
            m_EnergyPercentage = 100 * (i_CurrentEnergy / i_MaxEnergyCapacity);
        }

        public abstract void UpdateEnergyPercentage();

      /*  public static void AddNewEngineCapacity(eVeichleType i_VeicleType, float i_EnergyCapacity)
        {
            if (!r_EnergyCapacityDict.ContainsKey(i_VeicleType))
            {
                r_EnergyCapacityDict.Add(i_VeicleType, i_EnergyCapacity);
            }
        }*/

    }
}
