// <copyright file="ParkingRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using ParkingLotModelLayer;

    /// <summary>
    /// Parking Lot Repository.
    /// </summary>
    public class ParkingRepository : IParkingRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public ParkingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.connection = new SqlConnection(this.connectionString);
        }

        /// <summary>
        /// Inherit Add Vehicle To Park Method.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        public Parking AddVehicleToParking(Parking parking)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spParkVehicle", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VehicleNumber", parking.VehicleNumber);
                    command.Parameters.AddWithValue("@ParkingType", parking.ParkingType);
                    command.Parameters.AddWithValue("@DriverType", parking.DriverType);
                    command.Parameters.AddWithValue("@VehicleType", parking.VehicleType);
                    command.Parameters.AddWithValue("@SlotNumber", parking.SlotNumber);

                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return parking;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
