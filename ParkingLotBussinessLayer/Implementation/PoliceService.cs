// <copyright file="PoliceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.Implementation
{
    using ParkingLotBussinessLayer.Interface;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// Create Police Service Class.
    /// </summary>
    public class PoliceService : IPoliceService
    {
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PoliceService"/> class.
        /// </summary>
        /// <param name="parkingRepository"></param>
        public PoliceService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        public Parking ParkVehicle(Parking parking)
        {
            return this.parkingRepository.AddVehicleToParking(parking);
        }

        public VehicleDetails SearchByVehicleNumber(string vehicleNumber)
        {
            return this.parkingRepository.GetVehicleByVehicleNumber(vehicleNumber);
        }

        public VehicleDetails UnParkVehicle(int slotNumber)
        {
            return this.parkingRepository.UnParkVehicle(slotNumber);
        }
    }
}
