// <copyright file="Vehicles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vehicle Type Model For Vehicle Type Table.
    /// </summary>
    public class Vehicles
    {
        /// <summary>
        /// Gets or Sets Vehicle Type.
        /// </summary>
        [Required]
        public string VehicleType { get; set; }

        /// <summary>
        /// Gets or Sets Charge Of Vehicle.
        /// </summary>
        [Required]
        public int Charge { get; set; }
    }
}
