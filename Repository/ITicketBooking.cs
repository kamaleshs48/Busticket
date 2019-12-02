
using KanakHolidays.Models;


namespace KanakHolidays.Repository
{
    public interface ITicketBooking
    {
        SearchListModels GetSearchList(string Source, string Destination, string JourneyDate, string ReturnDate);
        SearchListModels GetBusSeat(int RouteID, string JourneyDate, string SourceID, string DestinationID, string SeatTempate);
        ResponseModels SaveTicket(TicketBookingModels models);
        ResponseModels UpdatePaymentStatus(string TicketNo, string PaymentID);
        RouteStopageModel GetRootStopage(int RouteID);


        int SaveStopage(int RouteID, int SourceID, string Time1, string Time2, string Time3, string Time4);
        int DeleteStopage(int stopageID);



        PrintTicketModels BindTicketForPrint(string TicketNo);
        TicketBookingModels GetTicketBookingList();

    }
       

}
