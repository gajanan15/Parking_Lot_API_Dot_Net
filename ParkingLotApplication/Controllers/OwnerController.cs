// <copyright file="OwnerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ParkingLotBussinessLayer;
    using ParkingLotModelLayer;

    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                Parking parkingVehicle = this.ownerService.ParkVehicle(parking);
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
                VehicleDetails unParkingVehicle = this.ownerService.UnParkVehicle(slotNumber);

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

        [Route("search/&vehicleNumber = {vehicleNumber}")]
        [HttpGet]
        public ActionResult SearchVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                VehicleDetails searchVehicle = this.ownerService.SearchByVehicleNumber(vehicleNumber);

                if (searchVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Find Successfully", searchVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", searchVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("search/{slotnumber}")]
        [HttpGet]
        public ActionResult SearchVehicleBySlotNumber(int slotnumber)
        {
            try
            {
                VehicleDetails searchVehicle = this.ownerService.SearchBySlotNumber(slotnumber);

                if (searchVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Find Successfully", searchVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", searchVehicle));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("vehicles")]
        [HttpGet]
        public ActionResult GetAllVehicles()
        {
            try
            {
                List<VehicleDetails> allVehicles = this.ownerService.GetAllVehicles();

                if (allVehicles != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Fetch All Vehicles", allVehicles));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", allVehicles));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }

        [Route("empty/slots")]
        [HttpGet]
        public ActionResult GetAllEmptySolts()
        {
            try
            {
                List<VehicleDetails> allVehicles = this.ownerService.GetAllEmptySlots();

                if (allVehicles != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Fetch All Empty Slots", allVehicles));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", allVehicles));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message));
            }
        }
    }
}
