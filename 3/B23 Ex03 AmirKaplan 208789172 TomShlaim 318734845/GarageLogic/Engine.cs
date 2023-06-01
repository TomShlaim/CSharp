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
        private static readonly Dictionary<eVeichleType, float> r_EnergyCapacityDict = new Dictionary<eVeichleType, float>
        {
            { eVeichleType.ElectricCar, 5.2f },
            { eVeichleType.ElectricMotorcycle, 2.6f },
            { eVeichleType.FuelCar, 46f },
            { eVeichleType.FuelMotorcycle, 6.4f },
            { eVeichleType.Truck, 135f }
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
