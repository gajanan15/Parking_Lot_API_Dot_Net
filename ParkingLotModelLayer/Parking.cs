// <copyright file="Parking.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Parking Model For Paking Table.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// Gets or sets Vehicle Number.
        /// </summary>
        [Required(ErrorMessage ="Vehicle Number Is Required")]
        [RegularExpression(@"[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}", ErrorMessage = "Please enter a valid Vehicle Number")]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or Sets Parking Type.
        /// </summary>
        [Required(ErrorMessage = "Parking Type Is Required")]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or Sets Driver Type.
        /// </summary>
        [Required(ErrorMessage = "Driver Type Is Required")]
        public int DriverType { get; set; }

        /// <summary>
        /// Gets or Sets Vehicle Type.
        /// </summary>
        [Required(ErrorMessage = "Vehicle Type Is Required")]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or Sets Sloat Number.
        /// </summary>
        [Required(ErrorMessage = "Slot Type Is Required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please Enter A Valid Slot Number")]
        public int SlotNumber { get; set; }

        /// <summary>
        /// Gets or sets entry Time.
        /// </summary>
        public DateTime EntryTime { get; set; }
    }
}
