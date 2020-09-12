// <copyright file="DriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.Implementation
{
    using System;
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

        public VehicleDetails ParkVehicle(Parking vehicle)
        {
            VehicleDetails parking = this.parkingRepository.AddVehicleToParking(vehicle);
            if (parking != null)
            {
                this.mSMQService.AddToQueue("Driver Parked Vehicle Having Number: " + parking.VehicleNumber + " At Time : " + parking.EntryTime);
            }

            return parking;

            // return this.parkingRepository.AddVehicleToParking(parking);
        }

        public VehicleDetails UnParkVehicle(int slotNumber)
        {
            VehicleDetails vehicleDetails = this.parkingRepository.UnParkVehicle(slotNumber);
            if (vehicleDetails != null)
            {
                TimeSpan timeDifference = vehicleDetails.ExitTime.Subtract(vehicleDetails.EntryTime);
                this.mSMQService.AddToQueue("Driver UnParked Vehicle Having Number: " + vehicleDetails.VehicleNumber + " At Time : " + vehicleDetails.ExitTime + " Total Parking Time : " + (int)timeDifference.TotalMinutes + " And Parking Charge : Rs. " + vehicleDetails.ParkingCharge);
            }

            return vehicleDetails;

            // return this.parkingRepository.UnParkVehicle(slotNumber);
        }
    }
}
