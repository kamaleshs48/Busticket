using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanakHolidays.Models;
using KanakHolidays.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KanakHolidays.Controllers
{
    [Route("api")]
    public class SampleDataController : Controller
    {




        public readonly ICommon _Repository;
        public readonly ITicketBooking _TicketBooking;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SampleDataController> _logger;

        public SampleDataController(ILogger<SampleDataController> logger, ICommon tempRep, ITicketBooking Itb)
        {
            _logger = logger;
            _Repository = tempRep;
            _TicketBooking = Itb;
        }



        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [Route("GetSourceList")]
        public IActionResult GetSourceList()
        {
            IndexModel models = new IndexModel();
            models = _Repository.BindHomePage();

            return new OkObjectResult(new { models, models.SourceList });




            //return Ok(models);
            // return Ok(Json("123"));

        }

        [Route("GetBusList")]
        public IActionResult GetBusList(string SourceID, string DestinationID, string JourneyDate, string ReturnDate)
        {


            ICommon _Repository = new Common();


            SearchListModels models = new SearchListModels();

            List<SeatModel> _List = new List<SeatModel>();
            models = _TicketBooking.GetSearchList(SourceID, DestinationID, JourneyDate, ReturnDate);

            IndexModel models1 = new IndexModel();
            models1 = _Repository.BindHomePage();

            //   var resp = _Repository.SaveEnquery(models);
            return new OkObjectResult(new { models, models.BusList, models1.SourceList, models.PickUpPointList, models.DropPointList, models.BusList[0].SeatList });
            //  var response = Request.CreateResponse(HttpStatusCode.OK, models);
            //   return response;

        }


   














public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
