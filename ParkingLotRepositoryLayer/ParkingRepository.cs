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

        public VehicleDetails UnParkVehicle(int slotNumber)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spUnParkVehicle", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return this.GetVehicleData(slotNumber);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public VehicleDetails GetVehicleData(int slotNumber)
        {
            VehicleDetails vehicleDetails = new VehicleDetails();

            using (this.connection)
            {
                SqlCommand command = new SqlCommand("spGetDetailsBySlotNumber", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SlotNumber", slotNumber);
                this.connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        vehicleDetails.Parking_Id = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                        vehicleDetails.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                        vehicleDetails.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                        vehicleDetails.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                        vehicleDetails.EntryTime = sqlDataReader["ENTRY_TIME"].ToString();
                        vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                        vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                        vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                        vehicleDetails.ExitTime = sqlDataReader["EXIT_TIME"].ToString();
                    }

                    this.connection.Close();
                    return vehicleDetails;
                }
            }

            return null;
        }

        public VehicleDetails GetVehicleByVehicleNumber(string vehicleNumber)
        {
            VehicleDetails vehicleDetails = new VehicleDetails();
            using (this.connection)
            {
                SqlCommand command = new SqlCommand("spGetDetailsByVehicleNumber", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VehicleNumber", vehicleNumber);
                this.connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        vehicleDetails.Parking_Id = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                        vehicleDetails.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                        vehicleDetails.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                        vehicleDetails.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                        vehicleDetails.EntryTime = sqlDataReader["ENTRY_TIME"].ToString();
                        vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                        vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                        vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                        vehicleDetails.ExitTime = sqlDataReader["EXIT_TIME"].ToString();
                    }

                    this.connection.Close();
                    return vehicleDetails;
                }
            }

            return null;
        }

        public List<VehicleDetails> GetAllVehicles()
        {
            List<VehicleDetails> vehicleDetailsList = new List<VehicleDetails>();

            using (this.connection)
            {
                SqlCommand command = new SqlCommand("spGetAllVehicles", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                this.connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        VehicleDetails vehicleDetails = new VehicleDetails();
                        vehicleDetails.Parking_Id = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                        vehicleDetails.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                        vehicleDetails.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                        vehicleDetails.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                        vehicleDetails.EntryTime = sqlDataReader["ENTRY_TIME"].ToString();
                        vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                        vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                        vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                        vehicleDetails.ExitTime = sqlDataReader["EXIT_TIME"].ToString();
                        vehicleDetailsList.Add(vehicleDetails);
                    }

                    this.connection.Close();
                    return vehicleDetailsList;
                }
            }

            return null;
        }

        public List<VehicleDetails> GetAllEmptySlots()
        {
            List<VehicleDetails> vehicleDetailsList = new List<VehicleDetails>();

            using (this.connection)
            {
                SqlCommand command = new SqlCommand("spGetEmptySlots", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                this.connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        VehicleDetails vehicleDetails = new VehicleDetails();
                        vehicleDetails.Parking_Id = Convert.ToInt32(sqlDataReader["PARKING_ID"]);
                        vehicleDetails.SlotNumber = Convert.ToInt32(sqlDataReader["SLOT_NUMBER"]);
                        vehicleDetails.VehicleNumber = sqlDataReader["VEHICLE_NUMBER"].ToString();
                        vehicleDetails.VehicleType = Convert.ToInt32(sqlDataReader["VEHICLE_TYPE"]);
                        vehicleDetails.EntryTime = sqlDataReader["ENTRY_TIME"].ToString();
                        vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                        vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                        vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                        vehicleDetails.ExitTime = sqlDataReader["EXIT_TIME"].ToString();
                        vehicleDetailsList.Add(vehicleDetails);
                    }

                    this.connection.Close();
                    return vehicleDetailsList;
                }
            }

            return null;
        }
    }
}
