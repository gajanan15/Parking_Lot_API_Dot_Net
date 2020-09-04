// <copyright file="Roles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Roles Type Model For Role Table.
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Gets or Sets Role Type.
        /// </summary>
        [Required]
        public string RoleType { get; set; }

        /// <summary>
        /// Gets or Sets Charge Of Role.
        /// </summary>
        [Required]
        public int RoleCharge { get; set; }
    }
}
