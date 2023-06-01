using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class ElectricEngine : Engine
    {
        private float m_RemainingHoursInBattery;
        private readonly float r_MaxHoursOfBattery;

        public ElectricEngine(float i_MaxHoursOfBattery)
        {
            r_MaxHoursOfBattery = i_MaxHoursOfBattery;
        }

        public float RemainingHoursInBattery
        {
            get { return m_RemainingHoursInBattery; }
            set 
            {
                // Validation here (?)
                m_RemainingHoursInBattery = value;
                UpdateEnergyPercentage();
            }
        }

        public float MaxHoursOfBattery
        {
            get { return m_RemainingHoursInBattery; }
        }

        public override void UpdateEnergyPercentage()
        {
            base.SetEnergyPercentage(m_RemainingHoursInBattery, r_MaxHoursOfBattery);
        }

        public void RechargeBattery(float i_HoursToAdd)
        {
            // Validation here (?)
            m_RemainingHoursInBattery += i_HoursToAdd;
            UpdateEnergyPercentage();
        }

        public override string ToString()
        {
            return string.Format(
@"Electric Engine
Remaining battery life:{0} hours
Maximum battery capacity: {1} hours
Energy Percentage:{2}%"
, m_RemainingHoursInBattery, r_MaxHoursOfBattery, base.EnergyPercentage);
        }
    }
}
