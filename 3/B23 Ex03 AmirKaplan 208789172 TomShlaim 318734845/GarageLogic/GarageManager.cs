using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    internal class GarageManager
    {
        private Dictionary<string, VehicleInfo> m_VehiclesInGarage;

        public void AddVehicle(VehicleInfo i_VehicleInfo)
        {
            if (!isVehicleInGarage(i_VehicleInfo.Vehicle.RegistrationNumber))
            {
                m_VehiclesInGarage.Add(i_VehicleInfo.Vehicle.RegistrationNumber, i_VehicleInfo);
            }
        }
        public bool isVehicleInGarage(string i_VehicleRegistrationNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_VehicleRegistrationNumber);
        }
        public void UpdateVehicleStatus(string i_VehicleRegistrationNumber, eVehicleStatus i_NewVehicleStatus)
        {
            VehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                vehicleInGarage.VehicleStatus = i_NewVehicleStatus;
            }
        }
        public String GetVehiclesRegisterationNumbersByVehicleStatus(eVehicleStatus i_VehicleStatus = eVehicleStatus.None)
        {
            StringBuilder registerationNumbersByVehicleStatus = new StringBuilder();

            if (i_VehicleStatus == eVehicleStatus.None)
            {
                registerationNumbersByVehicleStatus.Append(m_VehiclesInGarage.Keys);
            }
            else
            {
                foreach (KeyValuePair<string, VehicleInfo> vehicleInGarage in m_VehiclesInGarage)
                {
                    string registerationNumber = vehicleInGarage.Key;
                    eVehicleStatus vehicleStatus = vehicleInGarage.Value.VehicleStatus;

                    if (vehicleStatus == i_VehicleStatus)
                    {
                        registerationNumbersByVehicleStatus.AppendLine(registerationNumber);
                    }
                }
            }

            return registerationNumbersByVehicleStatus.ToString();
        }
        public void InflateVehicleWheelsToMaximum(string i_VehicleRegistrationNumber)
        {
            VehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                vehicleInGarage.Vehicle.InflateWheelsToMaximumPressure();
            }
        }
        public void FuelVehicle(string i_VehicleRegistrationNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            VehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                FuelEngine fuelEngine = vehicleInGarage.Vehicle.Engine as FuelEngine;
                if (fuelEngine != null)
                {
                    fuelEngine.Refuel(i_AmountToFill, i_FuelType);
                }
            }
        }
        public void ChargeVehicle(string i_VehicleRegistrationNumber, float i_minutesToCharge)
        {
            VehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                ElectricEngine electricEngine = vehicleInGarage.Vehicle.Engine as ElectricEngine;
                if (electricEngine != null)
                {
                    electricEngine.RechargeBattery(i_minutesToCharge / 60);
                }
            }
        }
        public String GetAllVehiclesData()
        {
            //In order to get specific vehicle data (such as lisence for motorcycle), I think we should maybe add classes for each type and override ToString
            return "";
        }
    }
}
