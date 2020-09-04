// <copyright file="OwnerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotApplication.Controllers
{
    using System;
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
                if (parkingVehicle.VehicleNumber != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", null));
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
                VehicleDetails unParkingVehicle = this.ownerService.UnParkVehicle(slotNumber);

                if (unParkingVehicle != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", unParkingVehicle));
                }

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", null));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        [Route("search/slotnumber")]
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

                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", null));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }
    }
}
