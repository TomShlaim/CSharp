using System;

namespace GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentAmountOfLitersInFuelTank;
        private readonly float r_MaxLitersInFuelTank;

        public FuelEngine(eFuelType i_FuelType, float i_MaxLitersInFuelTank)
        {
            r_FuelType = i_FuelType;
            r_MaxLitersInFuelTank = i_MaxLitersInFuelTank;
        }
        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }
        public override void UpdateEnergyPercentage()
        {
            base.SetEnergyPercentage(m_CurrentAmountOfLitersInFuelTank, r_MaxLitersInFuelTank);
        }

        public void Refuel(float i_NumOfLiters, eFuelType i_FuelType)
        {
            if(r_FuelType != i_FuelType)
            {
                throw new ArgumentException(string.Format("Invalid fuel type! The engine fuel type is {0}", r_FuelType.ToString()));
            }
            else
            {
                if (m_CurrentAmountOfLitersInFuelTank + i_NumOfLiters <= r_MaxLitersInFuelTank)
                {
                    m_CurrentAmountOfLitersInFuelTank += i_NumOfLiters;
                    UpdateEnergyPercentage();
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxLitersInFuelTank);
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0} Fuel Engine
Liters in tank:{1}
Maximum liters in tank: {2}
Energy Percentage:{3}%"
,r_FuelType,m_CurrentAmountOfLitersInFuelTank, r_MaxLitersInFuelTank, base.EnergyPercentage);
        }
    }
}