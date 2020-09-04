// <copyright file="Users.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// USers Model  For Paking Type Table.
    /// </summary>
    public class Users
    {
        /// <summary>
        ///  Gets or sets User Role.
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Role { get; set; }

        /// <summary>
        /// Gets or Sets Email Address.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets User Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
