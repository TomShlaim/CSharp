using System.Collections.Generic;


namespace GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleAdditionalFields
        {
            LiscenseType,
            EngineVolume,
            Color,
            NumOfDoors,
            IsCarryingDangerousMaterial,
            IsRefrigeratedTransport,
    }
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_RegistrationNumber, string i_ModelName)
        {
            Vehicle vehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    vehicle = createFuelMotorcycle(i_RegistrationNumber, i_ModelName);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = createElectricMotorcycle(i_RegistrationNumber, i_ModelName);
                    break;
                case eVehicleType.FuelCar:
                    vehicle = createFuelCar(i_RegistrationNumber, i_ModelName);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = createElectricCar(i_RegistrationNumber, i_ModelName);
                    break;
                case eVehicleType.Truck:
                    vehicle = createTruck(i_RegistrationNumber, i_ModelName);
                    break;
            }

            return vehicle;
        }
        public static void SetVehicleAdditionalFields(Vehicle i_Vehicle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            switch (i_Vehicle)
            {
                case Motorcycle motorcycle:
                    setMotorcycleAdditonalFields(motorcycle, i_VehicleAdditionalFields);
                    break;
                case Car car:
                    setCarAdditonalFields(car, i_VehicleAdditionalFields);
                    break;
                case Truck truck:
                    setTruckAdditonalFields(truck, i_VehicleAdditionalFields);
                    break;

            }
        }
        public static List<eVehicleAdditionalFields> GetVehicleAdditionalFields(eVehicleType i_VehicleType)
        {
            List<eVehicleAdditionalFields> vehicleAdditionalFields = new List<eVehicleAdditionalFields>();
            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    vehicleAdditionalFields.AddRange(getMotorcycleAdditionalFields());
                    break;
                case eVehicleType.FuelCar:
                case eVehicleType.ElectricCar:
                    vehicleAdditionalFields.AddRange(getCarAdditionalFields());
                    break;
                case eVehicleType.Truck:
                    vehicleAdditionalFields.AddRange(getTruckAdditionalFields());
                    break;
            }

            return vehicleAdditionalFields;
        }
        private static Motorcycle createFuelMotorcycle(string i_RegistrationNumber, string i_ModelName)
        {
            FuelEngine fuelEngine = new FuelEngine(eFuelType.Octan98, 6.4f);

            return new Motorcycle(i_RegistrationNumber, i_ModelName, fuelEngine);
        }
        private static Motorcycle createElectricMotorcycle(string i_RegistrationNumber, string i_ModelName)
        {
            ElectricEngine electricEngine = new ElectricEngine(2.6f);

            return new Motorcycle(i_RegistrationNumber, i_ModelName, electricEngine);
        }
        private static Car createFuelCar(string i_RegistrationNumber, string i_ModelName)
        {
            FuelEngine fuelEngine = new FuelEngine(eFuelType.Octan95, 46f);

            return new Car(i_RegistrationNumber, i_ModelName, fuelEngine);
        }
        private static Car createElectricCar(string i_RegistrationNumber, string i_ModelName)
        {
            ElectricEngine electricEngine = new ElectricEngine(5.2f);

            return new Car(i_RegistrationNumber, i_ModelName, electricEngine);
        }
        private static Truck createTruck(string i_RegistrationNumber, string i_ModelName)
        {
            FuelEngine fuelEngine = new FuelEngine(eFuelType.Soler, 135f);

            return new Truck(i_RegistrationNumber, i_ModelName, fuelEngine);
        }
        private static void setMotorcycleAdditonalFields(Motorcycle i_Motorcycle, Dictionary<eVehicleAdditionalFields, string> i_VehicleAdditionalFields)
        {
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.EngineVolume, out string engineVolumeString);
            i_VehicleAdditionalFields.TryGetValue(eVehicleAdditionalFields.LiscenseType, out string liscenseTypeString);
            int engineVolume = LogicValidator.ValidateAndParseStringToInteger(engineVolumeString);
            //Convert liscense type here

            //Set motorcycle attributes here
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
            bool isCarryingDangerousMaterial = LogicValidator.ValidateAndParseStringToBoolean(isCarryingDangerousMaterialString);
            bool isRefrigeratedTransport = LogicValidator.ValidateAndParseStringToBoolean(isRefrigeratedTransportString);

            i_Truck.IsCarryingDangerousMaterial = isCarryingDangerousMaterial;
            i_Truck.IsRefrigeratedTransport = isRefrigeratedTransport;
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
                eVehicleAdditionalFields.IsCarryingDangerousMaterial
            };

            return truckAdditionalFields;
        }
    }
}
