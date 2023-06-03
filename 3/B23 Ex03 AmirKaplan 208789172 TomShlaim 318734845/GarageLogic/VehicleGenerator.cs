using GarageLogic;
using System.Collections.Generic;
using System.Linq;

namespace GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleAdditionalFields
        {
            AmountOfAirInWheels,
            CurrentAmountOfFuel,
            RemainingHoursInBattery,
            LicenseType,
            EngineVolume,
            Color,
            NumOfDoors,
            IsCarryingDangerousMaterial,
            IsRefrigeratedTransport,
            CargoVolume
        }
        private static readonly Dictionary<eVehicleType, float> r_EnergyCapacity = new Dictionary<eVehicleType, float>
        {
            { eVehicleType.FuelMotorcycle, 6.4f },
            { eVehicleType.ElectricMotorcycle, 2.6f },
            { eVehicleType.FuelCar, 46f },
            { eVehicleType.ElectricCar, 5.2f },
            { eVehicleType.Truck, 135f }
        };
        private static readonly Dictionary<eVehicleType, eFuelType> r_VehicleFuelType = new Dictionary<eVehicleType, eFuelType>
        {
            { eVehicleType.FuelMotorcycle, eFuelType.Octan98 },
            { eVehicleType.FuelCar, eFuelType.Octan95 },
            { eVehicleType.Truck, eFuelType.Soler }
        };
        internal static Vehicle createVehicle(eVehicleType i_VehicleType, string i_RegistrationNumber, string i_ModelName)
        {
            Vehicle vehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    vehicle = createFuelMotorcycle(i_RegistrationNumber, i_ModelName, eVehicleType.FuelMotorcycle);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = createElectricMotorcycle(i_RegistrationNumber, i_ModelName, eVehicleType.ElectricMotorcycle);
                    break;
                case eVehicleType.FuelCar:
                    vehicle = createFuelCar(i_RegistrationNumber, i_ModelName, eVehicleType.FuelCar);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = createElectricCar(i_RegistrationNumber, i_ModelName, eVehicleType.ElectricCar);
                    break;
                case eVehicleType.Truck:
                    vehicle = createTruck(i_RegistrationNumber, i_ModelName, eVehicleType.Truck);
                    break;
            }

            return vehicle;
        }
        internal static void setVehicleAdditionalField(Vehicle i_Vehicle, eVehicleAdditionalFields i_VehicleAdditionalField, string i_VehicleAdditionalFieldValue)
        {
            switch (i_VehicleAdditionalField)
            {
                case eVehicleAdditionalFields.CurrentAmountOfFuel:
                    float currentAmountOfFuel = LogicValidator.ValidateAndParseStringToPositiveFloat(i_VehicleAdditionalFieldValue);

                    if(i_Vehicle.Engine is FuelEngine fuelEngine)
                    {
                        fuelEngine.Refuel(currentAmountOfFuel, fuelEngine.FuelType);
                    }

                    break;
                case eVehicleAdditionalFields.RemainingHoursInBattery:
                    float remainingHoursInBattery = LogicValidator.ValidateAndParseStringToPositiveFloat(i_VehicleAdditionalFieldValue);

                    if (i_Vehicle.Engine is ElectricEngine electricEngine)
                    {
                        electricEngine.RechargeBattery(remainingHoursInBattery);
                    }

                    break;
                case eVehicleAdditionalFields.LicenseType:
                    eLicenseType licenseType = LogicValidator.ValidateAndParseLicenseType(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Motorcycle).LicenseType = licenseType;

                    break;
                case eVehicleAdditionalFields.EngineVolume:
                    int engineVolume = LogicValidator.ValidateAndParseStringToInteger(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Motorcycle).EngineVolume = engineVolume;

                    break;
                case eVehicleAdditionalFields.Color:
                    eCarColor carColor = LogicValidator.ValidateAndParseStringToCarColor(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Car).Color = carColor;

                    break;
                case eVehicleAdditionalFields.NumOfDoors:
                    eNumOfDoors carNumOfDoors = LogicValidator.ValidateAndParseStringToNumOfDoors(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Car).NumOfDoors = carNumOfDoors;

                    break;
                case eVehicleAdditionalFields.IsCarryingDangerousMaterial:
                    bool isCarryingDangerousMaterial = LogicValidator.ValidateAndParseStringToBoolean(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Truck).IsCarryingDangerousMaterial = isCarryingDangerousMaterial;

                    break;
                case eVehicleAdditionalFields.IsRefrigeratedTransport:
                    bool isRefrigeratedTransport = LogicValidator.ValidateAndParseStringToBoolean(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Truck).IsRefrigeratedTransport = isRefrigeratedTransport;

                    break;
                case eVehicleAdditionalFields.CargoVolume:
                    float cargoVolume = LogicValidator.ValidateAndParseStringToPositiveFloat(i_VehicleAdditionalFieldValue);

                    (i_Vehicle as Truck).CargoVolume = cargoVolume;

                    break;
                case eVehicleAdditionalFields.AmountOfAirInWheels:
                    float amountOfAirInWheels = LogicValidator.ValidateAndParseStringToPositiveFloat(i_VehicleAdditionalFieldValue);

                    i_Vehicle.InflateWheels(amountOfAirInWheels);

                    break;
            }
        }
    internal static List<eVehicleAdditionalFields> getVehicleAdditionalFields(eVehicleType i_VehicleType)
        {
            List<eVehicleAdditionalFields> vehicleAdditionalFields = new List<eVehicleAdditionalFields>();

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    vehicleAdditionalFields = getFuelMotorcycleAdditionalFields();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicleAdditionalFields = getElectricMotorcycleAdditionalFields();
                    break;
                case eVehicleType.FuelCar:
                    vehicleAdditionalFields = getFuelCarAdditionalFields();
                    break;
                case eVehicleType.ElectricCar:
                    vehicleAdditionalFields = getElectricCarAdditionalFields();
                    break;
                case eVehicleType.Truck:
                    vehicleAdditionalFields = getFuelTrackAdditionalFields();
                    break;
            }

            vehicleAdditionalFields.AddRange(getVehicleAdditionalFields());

            return vehicleAdditionalFields;
        }
        private static Motorcycle createFuelMotorcycle(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            FuelEngine fuelEngine = createFuelEngine(i_VehicleType);

            return new Motorcycle(i_RegistrationNumber, i_ModelName, fuelEngine, i_VehicleType);
        }
        private static Motorcycle createElectricMotorcycle(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            ElectricEngine electricEngine = createElectricEngine(i_VehicleType);

            return new Motorcycle(i_RegistrationNumber, i_ModelName, electricEngine, i_VehicleType);
        }
        private static Car createFuelCar(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            FuelEngine fuelEngine = createFuelEngine(i_VehicleType);

            return new Car(i_RegistrationNumber, i_ModelName, fuelEngine, i_VehicleType);
        }
        private static Car createElectricCar(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            ElectricEngine electricEngine = createElectricEngine(i_VehicleType);

            return new Car(i_RegistrationNumber, i_ModelName, electricEngine, i_VehicleType);
        }
        private static Truck createTruck(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            FuelEngine fuelEngine = createFuelEngine(i_VehicleType);

            return new Truck(i_RegistrationNumber, i_ModelName, fuelEngine, i_VehicleType);
        }
        private static FuelEngine createFuelEngine(eVehicleType i_VehicleType)
        {
            r_EnergyCapacity.TryGetValue(i_VehicleType, out float capacity);
            r_VehicleFuelType.TryGetValue(i_VehicleType, out eFuelType fuelType);

            return  new FuelEngine(fuelType, capacity);
        }
        private static ElectricEngine createElectricEngine(eVehicleType i_VehicleType)
        {
            r_EnergyCapacity.TryGetValue(i_VehicleType, out float capacity);

            return new ElectricEngine(capacity);
        }
        private static List<eVehicleAdditionalFields> getFuelMotorcycleAdditionalFields()
        {
            return getFuelVehicleAdditionalFields().Concat(getMotorcycleAdditionalFields()).ToList();
        }
        private static List<eVehicleAdditionalFields> getElectricMotorcycleAdditionalFields()
        {
            return getElectricVehicleAdditionalFields().Concat(getMotorcycleAdditionalFields()).ToList();
        }
        private static List<eVehicleAdditionalFields> getFuelCarAdditionalFields()
        {
            return getFuelVehicleAdditionalFields().Concat(getCarAdditionalFields()).ToList();
        }
        private static List<eVehicleAdditionalFields> getElectricCarAdditionalFields()
        {
            return getElectricVehicleAdditionalFields().Concat(getCarAdditionalFields()).ToList();
        }
        private static List<eVehicleAdditionalFields> getFuelTrackAdditionalFields()
        {
            return getFuelVehicleAdditionalFields().Concat(getTruckAdditionalFields()).ToList();
        }
        private static List<eVehicleAdditionalFields> getVehicleAdditionalFields()
        {
            return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.AmountOfAirInWheels
            };
        }
        private static List<eVehicleAdditionalFields> getMotorcycleAdditionalFields()
        {
            return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.LicenseType,
                eVehicleAdditionalFields.EngineVolume
            };
        }
        private static List<eVehicleAdditionalFields> getCarAdditionalFields()
        {
           return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.Color,
                eVehicleAdditionalFields.NumOfDoors
            };
        }
        private static List<eVehicleAdditionalFields> getTruckAdditionalFields()
        {
           return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.IsRefrigeratedTransport,
                eVehicleAdditionalFields.IsCarryingDangerousMaterial,
                eVehicleAdditionalFields.CargoVolume
            };
        }
        private static List<eVehicleAdditionalFields> getFuelVehicleAdditionalFields()
        {
            return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.CurrentAmountOfFuel,
            };
        }
        private static List<eVehicleAdditionalFields> getElectricVehicleAdditionalFields()
        {
            return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.RemainingHoursInBattery,
            };
        }
    }
}
