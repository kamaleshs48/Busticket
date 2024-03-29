﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanakHolidays.Models;
using KanakHolidays.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KanakHolidays.Controllers
{
    [Route("api")]
    [ApiController]
    public class KanakController : ControllerBase
    {

        public readonly ICommon _Repository;
        public readonly ITicketBooking _TicketBooking;
        public readonly IPackage _Package;

        private readonly ILogger<SampleDataController> _logger;

        public KanakController(ILogger<SampleDataController> logger, ICommon tempRep, ITicketBooking Itb, IPackage package)
        {
            _logger = logger;
            _Repository = tempRep;
            _TicketBooking = Itb;
            _Package = package;



        }



        [Route("GetBusSeatList")]
        [HttpGet]
        public IActionResult GetBusSeatList(int RouteID, string JourneyDate, string SourceID, string DestinationID, string SeatTempate)
        {


            

            ICommon _Repository = new Common();


            SearchListModels models = new SearchListModels();

            List<SeatModel> _List = new List<SeatModel>();
            models = _TicketBooking.GetBusSeat(RouteID, JourneyDate, SourceID, DestinationID, SeatTempate);


         
            //   var resp = _Repository.SaveEnquery(models);

            return new OkObjectResult(new { models, models.BusList[0].SeatList, });

        }

        [Route("UpdatePaymentStatus")]
        [HttpGet]
        public IActionResult UpdatePaymentStatus(string TicketNo, string PaymentID)
        {
            var x = _TicketBooking.UpdatePaymentStatus(TicketNo.Replace(@"\",""), PaymentID);
           
            return new OkObjectResult(x);

        }

        [Route("SaveTicket")]
        [HttpPost]
        public IActionResult SaveTicket(TicketBookingModels models)
        {

            var obj = _TicketBooking.SaveTicket(models);
            return Ok(obj);
        }
        [Route("PrintTicket")]
        [HttpGet]
        public IActionResult PrintTicket(string TicketNo)
        {
           

            PrintTicketModels models = new PrintTicketModels();

            models = _TicketBooking.BindTicketForPrint(TicketNo);
            return Ok(models);
        }

        [Route("GetPackageList")]
        [HttpGet]
        public IActionResult GetPackageList(int PackageTypeID)
        {
            PackageModels models = new PackageModels();
            models.PackageList = _Package.GetPackagesList(PackageTypeID);
            return Ok(models);
        }


    }
}