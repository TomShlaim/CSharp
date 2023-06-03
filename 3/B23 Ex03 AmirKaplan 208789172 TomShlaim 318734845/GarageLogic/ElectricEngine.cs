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
        public override void UpdateEnergyPercentage()
        {
            base.SetEnergyPercentage(m_RemainingHoursInBattery, r_MaxHoursOfBattery);
        }

        public void RechargeBattery(float i_HoursToAdd)
        {
            if (m_RemainingHoursInBattery + i_HoursToAdd <= r_MaxHoursOfBattery)
            {
                m_RemainingHoursInBattery += i_HoursToAdd;
                UpdateEnergyPercentage();
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxHoursOfBattery);
            }
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
