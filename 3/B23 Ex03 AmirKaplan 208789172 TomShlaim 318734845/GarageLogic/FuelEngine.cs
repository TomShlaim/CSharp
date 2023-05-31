using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentAmountOfLitersInFuelTank;
        private readonly float r_MaxLitersInFuelTank;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public FuelEngine(eFuelType i_FuelType, float i_MaxLitersInFuelTank)
        {
            r_FuelType = i_FuelType;
            r_MaxLitersInFuelTank = i_MaxLitersInFuelTank;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float CurrentAmountOfLitersInFuelTank
        {
            get { return m_CurrentAmountOfLitersInFuelTank; }

            set
            {
                // Validation here (?)
                m_CurrentAmountOfLitersInFuelTank = value;
                UpdateEnergyPercentage();
            }
        }

        public float MaxLitersInFuelTank
        {
            get { return r_MaxLitersInFuelTank; }
        }

        public void Refuel(float i_NumOfLiters, eFuelType i_FuelType)
        {
            // Validation here (?)
            m_CurrentAmountOfLitersInFuelTank += i_NumOfLiters;
            UpdateEnergyPercentage();
        }

        public override void UpdateEnergyPercentage()
        {
            base.SetEnergyPercentage(m_CurrentAmountOfLitersInFuelTank, r_MaxLitersInFuelTank);
        }

        public override string ToString()
        {
            return string.Format(
@"{0} Fuel Engine
Liters in tank:{1}
Maximum liters in tank: {2}
Energy Percentage:{3}"
,r_FuelType,m_CurrentAmountOfLitersInFuelTank, r_MaxLitersInFuelTank, base.EnergyPercentage);
        }
    }
}