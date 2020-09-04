// <copyright file="IParkingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;

    /// <summary>
    /// Repository interface.
    /// </summary>
    public interface IParkingRepository
    {
        /// <summary>
        /// Adding vehicle in parking.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        Parking AddVehicleToParking(Parking parking);

        VehicleDetails UnParkVehicle(int slotNumber);

        VehicleDetails GetVehicleData(int slotNumber);
    }
}
