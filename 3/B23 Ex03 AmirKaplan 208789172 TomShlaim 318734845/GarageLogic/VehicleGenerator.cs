using System.Collections.Generic;
using System.Linq;

namespace GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleAdditionalFields
        {
            CurrentAmountOfFuel,
            RemainingHoursInBattery,
            LiscenseType,
            EngineVolume,
            Color,
            NumOfDoors,
            IsCarryingDangerousMaterial,
            IsRefrigeratedTransport,
            CargoVolume
    }
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_RegistrationNumber, string i_ModelName)
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
        public static void SetVehicleAdditionalFields(Vehicle i_Vehicle, eVehicleType i_VehicleType, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    setFuelMotorcycleAdditionalFields(i_Vehicle, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    setElectricMotorcycleAdditionalFields(i_Vehicle, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.FuelCar:
                    setFuelCarAdditionalFields(i_Vehicle, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.ElectricCar:
                    setElectricCarAdditionalFields(i_Vehicle, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.Truck:
                    setFuelTruckAdditionalFields(i_Vehicle, i_VehicleAdditionalFields);
                    break;
            }
        }
        public static List<eVehicleAdditionalFields> GetVehicleAdditionalFields(eVehicleType i_VehicleType)
        {
            List<eVehicleAdditionalFields> vehicleAdditionalFields = null;
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

            return vehicleAdditionalFields;
        }
        private static Motorcycle createFuelMotorcycle(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            FuelEngine fuelEngine = new FuelEngine(eFuelType.Octan98, 6.4f);

            return new Motorcycle(i_RegistrationNumber, i_ModelName, fuelEngine, i_VehicleType);
        }
        private static Motorcycle createElectricMotorcycle(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            ElectricEngine electricEngine = new ElectricEngine(2.6f);

            return new Motorcycle(i_RegistrationNumber, i_ModelName, electricEngine, i_VehicleType);
        }
        private static Car createFuelCar(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            FuelEngine fuelEngine = new FuelEngine(eFuelType.Octan95, 46f);

            return new Car(i_RegistrationNumber, i_ModelName, fuelEngine, i_VehicleType);
        }
        private static Car createElectricCar(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            ElectricEngine electricEngine = new ElectricEngine(5.2f);

            return new Car(i_RegistrationNumber, i_ModelName, electricEngine, i_VehicleType);
        }
        private static Truck createTruck(string i_RegistrationNumber, string i_ModelName, eVehicleType i_VehicleType)
        {
            FuelEngine fuelEngine = new FuelEngine(eFuelType.Soler, 135f);

            return new Truck(i_RegistrationNumber, i_ModelName, fuelEngine, i_VehicleType);
        }
        private static void setFuelMotorcycleAdditionalFields(Vehicle i_Vehicle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            setFuelVehicleAdditionalFields(i_Vehicle.Engine as FuelEngine, i_VehicleAdditionalFields);
            setMotorcycleAdditonalFields(i_Vehicle as Motorcycle, i_VehicleAdditionalFields);
        }
        private static void setElectricMotorcycleAdditionalFields(Vehicle i_Vehicle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            setElectricVehicleAdditionalFields(i_Vehicle.Engine as ElectricEngine, i_VehicleAdditionalFields);
            setMotorcycleAdditonalFields(i_Vehicle as Motorcycle, i_VehicleAdditionalFields);
        }
        private static void setFuelCarAdditionalFields(Vehicle i_Vehicle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            setFuelVehicleAdditionalFields(i_Vehicle.Engine as FuelEngine, i_VehicleAdditionalFields);
            setCarAdditonalFields(i_Vehicle as Car, i_VehicleAdditionalFields);
        }
        private static void setElectricCarAdditionalFields(Vehicle i_Vehicle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            setElectricVehicleAdditionalFields(i_Vehicle.Engine as ElectricEngine, i_VehicleAdditionalFields);
            setCarAdditonalFields(i_Vehicle as Car, i_VehicleAdditionalFields);
        }
        private static void setFuelTruckAdditionalFields(Vehicle i_Vehicle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            setFuelVehicleAdditionalFields(i_Vehicle.Engine as FuelEngine, i_VehicleAdditionalFields);
            setTruckAdditonalFields(i_Vehicle as Truck, i_VehicleAdditionalFields);
        }
        private static void setMotorcycleAdditonalFields(Motorcycle i_Motorcycle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.EngineVolume, out string engineVolumeString)){
                int engineVolume = LogicValidator.ValidateAndParseStringToInteger(engineVolumeString);

                i_Motorcycle.EngineVolume = engineVolume;
            }
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.LiscenseType, out string liscenseTypeString))
            {
                eLicenseType licenseType = LogicValidator.ValidateAndParseLicenseType(liscenseTypeString);

                i_Motorcycle.LicenseType = licenseType;
            }
        }
        private static void setCarAdditonalFields(Car i_Car, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.Color, out string colorString))
            {
                eCarColor carColor = LogicValidator.ValidateAndParseStringToCarColor(colorString);

                i_Car.Color = carColor;
            }
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.NumOfDoors, out string numOfDoorsString))
            {
                eNumOfDoors carNumOfDoors = LogicValidator.ValidateAndParseStringToNumOfDoors(numOfDoorsString);

                i_Car.NumOfDoors = carNumOfDoors;
            }
        }
        private static void setTruckAdditonalFields(Truck i_Truck, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.IsCarryingDangerousMaterial, out string isCarryingDangerousMaterialString))
            {
                bool isCarryingDangerousMaterial = LogicValidator.ValidateAndParseStringToBoolean(isCarryingDangerousMaterialString);

                i_Truck.IsCarryingDangerousMaterial = isCarryingDangerousMaterial;
            }
            if (i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.IsRefrigeratedTransport, out string isRefrigeratedTransportString))
            {
                bool isRefrigeratedTransport = LogicValidator.ValidateAndParseStringToBoolean(isRefrigeratedTransportString);

                i_Truck.IsRefrigeratedTransport = isRefrigeratedTransport;
            }
            if (i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.CargoVolume, out string cargoVolumeString))
            {
                float cargoVolume = LogicValidator.ValidateAndParseStringToFloat(cargoVolumeString);

                i_Truck.CargoVolume = cargoVolume;
            }
        }
        private static void setFuelVehicleAdditionalFields(FuelEngine i_FuelEngine, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.CurrentAmountOfFuel, out string currentAmountOfFuelString))
            {
                float currentAmountOfFuel = LogicValidator.ValidateAndParseStringToFloat(currentAmountOfFuelString);

                i_FuelEngine.CurrentAmountOfLitersInFuelTank = currentAmountOfFuel;
            }
        }
        private static void setElectricVehicleAdditionalFields(ElectricEngine i_ElectricEngine, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            if(i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.RemainingHoursInBattery, out string remainingHoursInBatteryString))
            {
                float remainingHoursInBattery = LogicValidator.ValidateAndParseStringToFloat(remainingHoursInBatteryString);

                i_ElectricEngine.RemainingHoursInBattery = remainingHoursInBattery;
            }
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
        private static List<eVehicleAdditionalFields> getMotorcycleAdditionalFields()
        {
            return new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.LiscenseType,
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
