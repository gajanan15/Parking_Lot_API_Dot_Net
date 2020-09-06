// <copyright file="DriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.Implementation
{
    using ParkingLotBussinessLayer.Interface;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    public class DriverService : IDriverService
    {
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class.
        /// </summary>
        /// <param name="parkingRepository"></param>
        public DriverService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        public Parking ParkVehicle(Parking parking)
        {
            return this.parkingRepository.AddVehicleToParking(parking);
        }

        public VehicleDetails UnParkVehicle(int slotNumber)
        {
            return this.parkingRepository.UnParkVehicle(slotNumber);
        }
    }
}
