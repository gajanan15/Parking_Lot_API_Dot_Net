// <copyright file="IPoliceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.Interface
{
    using ParkingLotModelLayer;

    /// <summary>
    /// Create Police Service Interface.
    /// </summary>
    public interface IPoliceService
    {
        VehicleDetails ParkVehicle(Parking parking);

        VehicleDetails UnParkVehicle(int slotNumber);

        VehicleDetails SearchByVehicleNumber(string vehicleNumber);
    }
}
