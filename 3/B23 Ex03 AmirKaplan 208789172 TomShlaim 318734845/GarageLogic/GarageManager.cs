using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class GarageManager
    {
        private static Dictionary<string, GarageVehicleInfo> m_VehiclesInGarage = new Dictionary<string, GarageVehicleInfo>();

        public static void AddVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            VehicleOwner vehicleOwner = new VehicleOwner(i_OwnerName, i_OwnerPhone);
            GarageVehicleInfo garageVehicleInfo = new GarageVehicleInfo(i_Vehicle, vehicleOwner);


            if (!isVehicleInGarage(garageVehicleInfo.Vehicle.RegistrationNumber))
            {
                m_VehiclesInGarage.Add(garageVehicleInfo.Vehicle.RegistrationNumber, garageVehicleInfo);
            }
        }
        public static bool isVehicleInGarage(string i_VehicleRegistrationNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_VehicleRegistrationNumber);
        }
        public static void UpdateVehicleStatus(string i_VehicleRegistrationNumber, eVehicleStatus i_NewVehicleStatus)
        {
            GarageVehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                vehicleInGarage.VehicleStatus = i_NewVehicleStatus;
            }
            else
            {
                throw new ArgumentException("Invalid registeration number! Vehicle doesn't exist in garage");
            }
        }
        public static String GetVehiclesRegisterationNumbersByVehicleStatus(eVehicleStatus i_VehicleStatus = eVehicleStatus.None)
        {
            StringBuilder registerationNumbersByVehicleStatus = new StringBuilder();

            if (i_VehicleStatus == eVehicleStatus.None)
            {
                registerationNumbersByVehicleStatus.Append(m_VehiclesInGarage.Keys);
            }
            else
            {
                foreach (KeyValuePair<string, GarageVehicleInfo> vehicleInGarage in m_VehiclesInGarage)
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
        public static void InflateVehicleWheelsToMaximum(string i_VehicleRegistrationNumber)
        {
            GarageVehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                vehicleInGarage.Vehicle.InflateWheelsToMaximumPressure();
            }
            else
            {
                throw new ArgumentException("Invalid registeration number! Vehicle doesn't exist in garage");
            }
        }
        public static void FuelVehicle(string i_VehicleRegistrationNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            GarageVehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                if (vehicleInGarage.Vehicle.Engine is FuelEngine fuelEngine)
                {
                    fuelEngine.Refuel(i_AmountToFill, i_FuelType);
                }
            }
            else
            {
                throw new ArgumentException("Invalid registeration number! Vehicle doesn't exist in garage");
            }
        }
        public static void ChargeVehicle(string i_VehicleRegistrationNumber, float i_minutesToCharge)
        {
            GarageVehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                if (vehicleInGarage.Vehicle.Engine is ElectricEngine electricEngine)
                {
                    electricEngine.RechargeBattery(i_minutesToCharge / 60);
                }
            }
            else
            {
                throw new ArgumentException("Invalid registeration number! Vehicle doesn't exist in garage");
            }
        }
        public static string GetAllVehicleData(string i_VehicleRegistrationNumber)
        {
            GarageVehicleInfo vehicleInGarage;

            if (m_VehiclesInGarage.TryGetValue(i_VehicleRegistrationNumber, out vehicleInGarage))
            {
                return vehicleInGarage.ToString();
            }
            else
            {
                throw new ArgumentException("Invalid registeration number! Vehicle doesn't exist in garage");
            }
        }
    }
}
