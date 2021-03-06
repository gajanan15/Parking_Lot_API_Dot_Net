﻿// <copyright file="ParkingRepository.cs" company="PlaceholderCompany">
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
        public VehicleDetails AddVehicleToParking(Parking parking)
        {
            try
            {
                VehicleDetails vehicleDetails = new VehicleDetails();
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
                        vehicleDetails = this.GetVehicleByVehicleNumber(parking.VehicleNumber);
                        return vehicleDetails;
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
                VehicleDetails vehicleDetails = new VehicleDetails();
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
                        vehicleDetails = this.GetVehicleData(slotNumber);
                        return vehicleDetails;
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

            try
            {
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
                            vehicleDetails.EntryTime = (DateTime)sqlDataReader["ENTRY_TIME"];
                            vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                            vehicleDetails.ExitTime = (DateTime)sqlDataReader["EXIT_TIME"];
                            vehicleDetails.ParkingCharge = Convert.ToInt32(sqlDataReader["CHARGES"]);
                        }

                        this.connection.Close();
                        if (vehicleDetails != null)
                        {
                            vehicleDetails.RoleType = this.GetDriverType(vehicleDetails.SlotNumber);
                            return vehicleDetails;
                        }
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public VehicleDetails GetVehicleByVehicleNumber(string vehicleNumber)
        {
            VehicleDetails vehicleDetails = new VehicleDetails();

            try
            {
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
                            vehicleDetails.EntryTime = (DateTime)sqlDataReader["ENTRY_TIME"];
                            vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                            vehicleDetails.ExitTime = (DateTime)sqlDataReader["EXIT_TIME"];
                            vehicleDetails.ParkingCharge = Convert.ToInt32(sqlDataReader["CHARGES"]);
                        }

                        this.connection.Close();
                        if (vehicleDetails != null)
                        {
                            vehicleDetails.RoleType = this.GetDriverType(vehicleDetails.SlotNumber);
                            return vehicleDetails;
                        }
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<VehicleDetails> GetAllVehicles()
        {
            List<VehicleDetails> vehicleDetailsList = new List<VehicleDetails>();

            try
            {
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
                            vehicleDetails.EntryTime = (DateTime)sqlDataReader["ENTRY_TIME"];
                            vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                            vehicleDetails.ExitTime = (DateTime)sqlDataReader["EXIT_TIME"];
                            vehicleDetails.ParkingCharge = Convert.ToInt32(sqlDataReader["CHARGES"]);
                            vehicleDetailsList.Add(vehicleDetails);
                        }

                        this.connection.Close();
                        return vehicleDetailsList;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<VehicleDetails> GetAllEmptySlots()
        {
            List<VehicleDetails> vehicleDetailsList = new List<VehicleDetails>();

            try
            {
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
                            vehicleDetails.EntryTime = (DateTime)sqlDataReader["ENTRY_TIME"];
                            vehicleDetails.ParkingType = Convert.ToInt32(sqlDataReader["PARKING_TYPE"]);
                            vehicleDetails.DriverType = Convert.ToInt32(sqlDataReader["DRIVER_TYPE"]);
                            vehicleDetails.Disabled = sqlDataReader["DISABLED"].ToString();
                            vehicleDetails.ExitTime = (DateTime)sqlDataReader["EXIT_TIME"];
                            vehicleDetails.ParkingCharge = Convert.ToInt32(sqlDataReader["CHARGES"]);
                            vehicleDetailsList.Add(vehicleDetails);
                        }

                        this.connection.Close();
                        return vehicleDetailsList;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string GetDriverType(int slotNumber)
        {
            Roles roles = new Roles();
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetDriverType", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SlotNumber", slotNumber);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            roles.RoleType = sqlDataReader["ROLE_TYPE"].ToString();
                        }

                        this.connection.Close();
                        return roles.RoleType;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
