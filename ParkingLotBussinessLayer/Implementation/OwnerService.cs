// <copyright file="OwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// Create Owner Service Class.
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly IParkingRepository parkingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerService"/> class.
        /// </summary>
        /// <param name="parkingRepository"></param>
        public OwnerService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        /// <summary>
        /// Implements Method.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        public Parking ParkVehicle(Parking parking)
        {
             return this.parkingRepository.AddVehicleToParking(parking);
        }

        public VehicleDetails SearchBySlotNumber(int slotNumber)
        {
            return this.parkingRepository.GetVehicleData(slotNumber);
        }

        public VehicleDetails SearchByVehicleNumber(string vehicleNumber)
        {
            return this.parkingRepository.GetVehicleByVehicleNumber(vehicleNumber);
        }

        public List<VehicleDetails> GetAllVehicles()
        {
            return this.parkingRepository.GetAllVehicles();
        }

        public VehicleDetails UnParkVehicle(int slotNumber)
        {
            return this.parkingRepository.UnParkVehicle(slotNumber);
        }
    }
}
