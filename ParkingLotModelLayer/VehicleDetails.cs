// <copyright file="VehicleDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Create Vehicle Details.
    /// </summary>
    public class VehicleDetails
    {
        /// <summary>
        /// Gets or Sets Parking Id.
        /// </summary>
        public int Parking_Id { get; set; }

        /// <summary>
        /// Gets or Sets Sloat Number.
        /// </summary>
        [Required]
        public int SlotNumber { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Number.
        /// </summary>
        [Required]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or Sets Vehicle Type.
        /// </summary>
        [Required]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets entry Time.
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// Gets or Sets Parking Type.
        /// </summary>
        [Required]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or Sets Driver Type.
        /// </summary>
        [Required]
        public int DriverType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether disabled.
        /// </summary>
        public string Disabled { get; set; }

        /// <summary>
        /// Gets or sets Exit Time.
        /// </summary>
        public DateTime ExitTime { get; set; }

        /// <summary>
        /// Gets Or Sets Parking Charge.
        /// </summary>
        public int ParkingCharge { get; set; }

        public string RoleType { get; set; }
    }
}
