﻿// <copyright file="DriverService.cs" company="PlaceholderCompany">
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
        private MSMQService mSMQService = new MSMQService();

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class.
        /// </summary>
        /// <param name="parkingRepository"></param>
        public DriverService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        public Parking ParkVehicle(Parking vehicle)
        {
            Parking parking = this.parkingRepository.AddVehicleToParking(vehicle);
            if (parking.VehicleNumber != null)
            {
                this.mSMQService.AddToQueue("Driver Parked Vehicle Having Number: " + parking.VehicleNumber + " At Time : " + parking.EntryTime);
            }

            return parking;

            // return this.parkingRepository.AddVehicleToParking(parking);
        }

        public VehicleDetails UnParkVehicle(int slotNumber)
        {
            VehicleDetails vehicleDetails = this.parkingRepository.UnParkVehicle(slotNumber);
            if (vehicleDetails.VehicleNumber != null)
            {
                this.mSMQService.AddToQueue("Driver UnParked Vehicle Having Number: " + vehicleDetails.VehicleNumber + " At Time : " + vehicleDetails.ExitTime + " And Parking Charge : " + vehicleDetails.ParkingCharge);
            }

            return vehicleDetails;

            // return this.parkingRepository.UnParkVehicle(slotNumber);
        }
    }
}
