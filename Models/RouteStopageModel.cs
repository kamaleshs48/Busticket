using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanakHolidays.Models
{
    public class RouteStopageModel
    {
        public List<SelectListItem> SourceList = new List<SelectListItem>();
        public int StopageMapID { get; set; }
        public string RouteID { get; set; }
        public string SourceID { get; set; }
        public string SourceName { get; set; }
        public string DestinationID { get; set; }
        public string DestinationName { get; set; }
        public string Arrival_Time { get; set; }
        public string Departure_Time { get; set; }
        public string PickUp_Point1_Time { get; set; }
        public string PickUp_Point2_Time { get; set; }
        public string PickUp_Point3_Time { get; set; }
        public string PickUp_Point4_Time { get; set; }


        public List<RouteStopageModel> StopageList = new List<RouteStopageModel>();
    }
}