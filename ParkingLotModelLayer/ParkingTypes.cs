// <copyright file="ParkingTypes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Parking Types For Parking Type Table.
    /// </summary>
    public class ParkingTypes
    {
        /// <summary>
        /// Gets or Sets Parking Type.
        /// </summary>
        [Required]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or Sets Charge Of Parking.
        /// </summary>
        [Required]
        public int ParkingCharge { get; set; }
    }
}
