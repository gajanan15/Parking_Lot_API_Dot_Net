// <copyright file="SecurityController.cs" company="PlaceholderCompany">
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
    public class SecurityController : ControllerBase
    {
        private readonly IPoliceService policeService;

        public SecurityController(IPoliceService policeService)
        {
            this.policeService = policeService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                VehicleDetails parkingVehicle = this.policeService.ParkVehicle(parking);
                if (parkingVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", parkingVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult UnParkVehicle(int slotNumber)
        {
            try
            {
                VehicleDetails unParkingVehicle = this.policeService.UnParkVehicle(slotNumber);

                if (unParkingVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", unParkingVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", unParkingVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("search/&vehicleNumber={vehicleNumber}")]
        [HttpGet]
        public ActionResult SearchVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                VehicleDetails searchVehicle = this.policeService.SearchByVehicleNumber(vehicleNumber);

                if (searchVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Find Successfully", searchVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", searchVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }
    }
}
