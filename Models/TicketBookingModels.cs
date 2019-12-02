using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanakHolidays.Models
{
    public class TicketBookingModels
    {


        public string SourceID { get; set; }
        public string DestinationID { get; set; }

        public string RouteID { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string JourneyDate { get; set; }
        public string TicketNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string MobileCountryCode { get; set; }
        public List<PassengerDetails> PassengerList = new List<PassengerDetails>();
        public string TotalAmount { get; set; }

        public string TravelInsuranceAmount { get; set; }
        public int IsTravelInsurance { get; set; }
        public string GSTAmount { get; set; }
        public string TotalPayableAmount { get; set; }


        public int PickUpPoint { get; set; }
        public int DropPoint { get; set; }
        public string PaymentID { get; set; }
        public List<TicketBookingModels> TicketList = new List<TicketBookingModels>();






    }
    public class PassengerDetails
    {
        public string SeatNo { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }

    }

    public class PrintTicketModels
    {
        
        public string BusName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string TicketNo { get; set; }
        public string JournyStartDate { get; set; }
        public string JournyEndDate { get; set; }
        public string JournyStartTime { get; set; }
        public string JournyEndTime { get; set; }

        public string PickUPPoint { get; set; }
        public string PickUPPoint_LendMark { get; set; }
        public string PickUPPoint_Address { get; set; }
        public string DropPoint { get; set; }
        public string DropPoint_LendMark { get; set; }
        public string DropPoint_Address { get; set; }

        public string TotalFare { get; set; }

        public List<PassengerDetails> PassengerList = new List<PassengerDetails>();

    }

}