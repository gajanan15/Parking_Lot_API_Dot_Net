// <copyright file="PoliceController.cs" company="PlaceholderCompany">
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
    public class PoliceController : ControllerBase
    {
        private readonly IPoliceService policeService;

        public PoliceController(IPoliceService policeService)
        {
            this.policeService = policeService;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult ParkVehicle([FromBody] Parking parking)
        {
            try
            {
                Parking parkingVehicle = this.policeService.ParkVehicle(parking);
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
    }
}
