// <copyright file="OwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer
{
    using System.Collections.Generic;
    using ParkingLotBussinessLayer.Implementation;
    using ParkingLotModelLayer;
    using ParkingLotRepositoryLayer;

    /// <summary>
    /// Create Owner Service Class.
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly IParkingRepository parkingRepository;

        private MSMQService mSMQService = new MSMQService();

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
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public Parking ParkVehicle(Parking vehicle)
        {
            Parking parking = this.parkingRepository.AddVehicleToParking(vehicle);
            if (parking.VehicleNumber != null)
            {
                this.mSMQService.AddToQueue("Driver Parked Vehicle Having Number: " + parking.VehicleNumber + " At Time : " + parking.EntryTime);
            }

            return parking;
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
            VehicleDetails vehicleDetails = this.parkingRepository.UnParkVehicle(slotNumber);
            if (vehicleDetails.VehicleNumber != null)
            {
                this.mSMQService.AddToQueue("Driver UnParked Vehicle Having Number: " + vehicleDetails.VehicleNumber + " At Time : " + vehicleDetails.ExitTime + " And Parking Charge : " + vehicleDetails.ParkingCharge);
            }

            return vehicleDetails;

            // return this.parkingRepository.UnParkVehicle(slotNumber);
        }

        public List<VehicleDetails> GetAllEmptySlots()
        {
            return this.parkingRepository.GetAllEmptySlots();
        }
    }
}
