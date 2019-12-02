using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace KanakHolidays.Areas.Admin.Models
{
    public class RouteModels
    {

        private List<SelectListItem> _Travel_FrequencyList = new List<SelectListItem>() {
                new SelectListItem { Text="Daily",Value="Daily"},
                new SelectListItem {Text="Alternate",Value="Alternate" },
                new SelectListItem {Text="Custom",Value="Custom" },


        };
        private bool _IsActive = true;

        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public string ActionMode { get; set; }


        public int RouteID { get; set; }

        public string BusName { get; set; }

        public string Source { get; set; }
        public int SourceID { get; set; }
        public string Destination { get; set; }
        public int DestinationID { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string TravelTime { get; set; }
        public string TotalSeat { get; set; }
        public string TicketPrice { get; set; }
        public string Discount { get; set; }
        public string Travel_Frequency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public List<SelectListItem> Travel_FrequencyList { get { return _Travel_FrequencyList; } }

        public List<RouteModels> RouteList = new List<RouteModels>();
        public List<SelectListItem> SourceList = new List<SelectListItem>();

    }
}