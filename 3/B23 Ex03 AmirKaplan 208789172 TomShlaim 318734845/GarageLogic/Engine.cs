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
