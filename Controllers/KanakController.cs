using System;
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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SampleDataController> _logger;

        public KanakController(ILogger<SampleDataController> logger, ICommon tempRep, ITicketBooking Itb)
        {
            _logger = logger;
            _Repository = tempRep;
            _TicketBooking = Itb;
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

    }
}