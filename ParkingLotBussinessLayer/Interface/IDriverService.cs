// <copyright file="IDriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.Interface
{
    using ParkingLotModelLayer;

    /// <summary>
    /// Create Driver Service Interface.
    /// </summary>
    public interface IDriverService
    {
        Parking ParkVehicle(Parking parking);

        VehicleDetails UnParkVehicle(int slotNumber);
    }
}
