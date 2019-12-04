using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanakHolidays.Models
{
    public class SearchListModels
    {
        public string SourceID { get; set; }
        public string TicketNo { get { return Repository.CommonFunction.GetTicketNo(); } }
       
        public string DestinationID { get; set; }
        public string JourneyDate { get; set; }
        public string ReturnDate { get; set; }
        public List<BusModels> BusList = new List<BusModels>();

        public string PickUpPoint { get; set; }
        public string DropPoint { get; set; }
        public List<SelectListItem> PickUpPointList = new List<SelectListItem>();
        public List<SelectListItem> DropPointList = new List<SelectListItem>();
        public List<SelectListItem> SourceList = new List<SelectListItem>();


    }

    public class BusModels

    {
        public string SeatTempate { get; set; }
        public int RouteID { get; set; }
        public string BusName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Travel_Time { get; set; }
        public string Total_Fare { get; set; }
        public string Discount { get; set; }
        public string SeatLeft { get; set; }
        public List<SeatModel> Lower_SeatList_R1 = new List<SeatModel>();
        public List<SeatModel> Lower_SeatList_R2 = new List<SeatModel>();
        public List<SeatModel> Lower_SeatList_R3 = new List<SeatModel>();
        public List<SeatModel> Lower_SeatList_R4 = new List<SeatModel>();


        public List<SeatModel> SeatList = new List<SeatModel>();
        public bool IsOpenSeatChart { get; set; }
    }
    public class SeatModel
    {
        public string SeatNo { get; set; }
        public string SeatPrice { get; set; }
        public bool IsSold { get; set; }
        public bool isFemale { get; set; }

        public string CssClass { get; set; }
        public string SeatDiscount { get; set; }



    }
}