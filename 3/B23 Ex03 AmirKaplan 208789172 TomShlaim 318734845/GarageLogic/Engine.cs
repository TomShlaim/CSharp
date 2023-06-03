using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Engine
    {
        private float m_EnergyPercentage;

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
    }
}
