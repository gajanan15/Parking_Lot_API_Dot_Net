// <copyright file="DriverController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication.Controllers
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBussinessLayer.Interface;
    using ParkingLotModelLayer;

    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                VehicleDetails parkingVehicle = this.driverService.ParkVehicle(parking);
                if (parkingVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", parkingVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult UnParkVehicle(int slotNumber)
        {
            try
            {
                VehicleDetails unParkingVehicle = this.driverService.UnParkVehicle(slotNumber);

                if (unParkingVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", unParkingVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", unParkingVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }
    }
}
