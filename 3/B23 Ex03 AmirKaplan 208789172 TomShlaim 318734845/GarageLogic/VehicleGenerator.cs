using System.Collections.Generic;
using System.Diagnostics;
using static GarageLogic.VehicleGenerator;


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
                    setFuelVehicleAdditionalFields(i_Vehicle.Engine as FuelEngine, i_VehicleAdditionalFields);
                    setMotorcycleAdditonalFields(i_Vehicle as Motorcycle, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    setElectricVehicleAdditionalFields(i_Vehicle.Engine as ElectricEngine, i_VehicleAdditionalFields);
                    setMotorcycleAdditonalFields(i_Vehicle as Motorcycle, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.FuelCar:
                    setFuelVehicleAdditionalFields(i_Vehicle.Engine as FuelEngine, i_VehicleAdditionalFields);
                    setCarAdditonalFields(i_Vehicle as Car, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.ElectricCar:
                    setElectricVehicleAdditionalFields(i_Vehicle.Engine as ElectricEngine, i_VehicleAdditionalFields);
                    setCarAdditonalFields(i_Vehicle as Car, i_VehicleAdditionalFields);
                    break;
                case eVehicleType.Truck:
                    setFuelVehicleAdditionalFields(i_Vehicle.Engine as FuelEngine, i_VehicleAdditionalFields);
                    setTruckAdditonalFields(i_Vehicle as Truck, i_VehicleAdditionalFields);
                    break;
            }
        }
        public static List<eVehicleAdditionalFields> GetVehicleAdditionalFields(eVehicleType i_VehicleType)
        {
            List<eVehicleAdditionalFields> vehicleAdditionalFields = new List<eVehicleAdditionalFields>();
            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    vehicleAdditionalFields.AddRange(getMotorcycleAdditionalFields());
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicleAdditionalFields.AddRange(getMotorcycleAdditionalFields());
                    break;
                case eVehicleType.FuelCar:
                    vehicleAdditionalFields.AddRange(getCarAdditionalFields());
                    break;
                case eVehicleType.ElectricCar:
                    vehicleAdditionalFields.AddRange(getCarAdditionalFields());
                    break;
                case eVehicleType.Truck:
                    vehicleAdditionalFields.AddRange(getTruckAdditionalFields());
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
        private static void setMotorcycleAdditonalFields(Motorcycle i_Motorcycle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.EngineVolume, out string engineVolumeString);
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.LiscenseType, out string liscenseTypeString);
            int engineVolume = LogicValidator.ValidateAndParseStringToInteger(engineVolumeString);
            eLicenseType licenseType = LogicValidator.ValidateAndParseLicenseType(liscenseTypeString);

            i_Motorcycle.EngineVolume = engineVolume;
            i_Motorcycle.LicenseType = licenseType;
        }
        private static void setCarAdditonalFields(Car i_Car, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.Color, out string colorString);
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.NumOfDoors, out string numOfDoorsString);
            eCarColor carColor = LogicValidator.ValidateAndParseStringToCarColor(colorString);
            eNumOfDoors carNumOfDoors = LogicValidator.ValidateAndParseStringToNumOfDoors(numOfDoorsString);

            i_Car.Color = carColor;
            i_Car.NumOfDoors = carNumOfDoors;
        }
        private static void setTruckAdditonalFields(Truck i_Truck, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.IsCarryingDangerousMaterial, out string isCarryingDangerousMaterialString);
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.IsRefrigeratedTransport, out string isRefrigeratedTransportString);
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.CargoVolume, out string cargoVolumeString);
            bool isCarryingDangerousMaterial = LogicValidator.ValidateAndParseStringToBoolean(isCarryingDangerousMaterialString);
            bool isRefrigeratedTransport = LogicValidator.ValidateAndParseStringToBoolean(isRefrigeratedTransportString);
            float cargoVolume = LogicValidator.ValidateAndParseStringToFloat(cargoVolumeString);

            i_Truck.IsCarryingDangerousMaterial = isCarryingDangerousMaterial;
            i_Truck.IsRefrigeratedTransport = isRefrigeratedTransport;
            i_Truck.CargoVolume = cargoVolume;
        }
        private static void setFuelVehicleAdditionalFields(FuelEngine i_FuelEngine, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.CurrentAmountOfFuel, out string currentAmountOfFuelString);
            float currentAmountOfFuel = LogicValidator.ValidateAndParseStringToFloat(currentAmountOfFuelString);

            i_FuelEngine.CurrentAmountOfLitersInFuelTank = currentAmountOfFuel;
        }
        private static void setElectricVehicleAdditionalFields(ElectricEngine i_ElectricEngine, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.RemainingHoursInBattery, out string remainingHoursInBatteryString);
            float remainingHoursInBattery = LogicValidator.ValidateAndParseStringToFloat(remainingHoursInBatteryString);

            i_ElectricEngine.RemainingHoursInBattery = remainingHoursInBattery;
        }
        private static List<eVehicleAdditionalFields> getMotorcycleAdditionalFields()
        {
            List<eVehicleAdditionalFields> motorcycleAdditionalFields = new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.LiscenseType,
                eVehicleAdditionalFields.EngineVolume
            };

            return motorcycleAdditionalFields;
        }
        private static List<eVehicleAdditionalFields> getCarAdditionalFields()
        {
            List<eVehicleAdditionalFields> carAdditionalFields = new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.Color,
                eVehicleAdditionalFields.NumOfDoors
            };

            return carAdditionalFields;
        }
        private static List<eVehicleAdditionalFields> getTruckAdditionalFields()
        {
            List<eVehicleAdditionalFields> truckAdditionalFields = new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.IsRefrigeratedTransport,
                eVehicleAdditionalFields.IsCarryingDangerousMaterial,
                eVehicleAdditionalFields.CargoVolume
            };

            return truckAdditionalFields;
        }
        private static List<eVehicleAdditionalFields> getFuelVehicleAdditionalFields()
        {
            List<eVehicleAdditionalFields> fuelVehicleAdditionalFields = new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.CurrentAmountOfFuel,
            };

            return fuelVehicleAdditionalFields;
        }
        private static List<eVehicleAdditionalFields> getElectricVehicleAdditionalFields()
        {
            List<eVehicleAdditionalFields> electricVehicleAdditionalFields = new List<eVehicleAdditionalFields>
            {
                eVehicleAdditionalFields.RemainingHoursInBattery,
            };

            return electricVehicleAdditionalFields;
        }
    }
}
