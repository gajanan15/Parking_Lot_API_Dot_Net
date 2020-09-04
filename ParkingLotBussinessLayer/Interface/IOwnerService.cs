// <copyright file="IOwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System.Collections.Generic;
    using ParkingLotModelLayer;

    /// <summary>
    /// Create Owner Service Interface.
    /// </summary>
    public interface IOwnerService
    {
        /// <summary>
        /// Create Owner Service Interface.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        Parking ParkVehicle(Parking parking);

        VehicleDetails UnParkVehicle(int slotNumber);

        VehicleDetails SearchByVehicleNumber(string vehicleNumber);

        VehicleDetails SearchBySlotNumber(int slotNumber);

        List<VehicleDetails> GetAllVehicles();

        List<VehicleDetails> GetAllEmptySlots();
    }
}
