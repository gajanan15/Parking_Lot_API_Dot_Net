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
        Parking ParkVehicle(Parking parking);
    }
}
