using KanakHolidays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using KanakHolidays.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KanakHolidays.Repository
{
    public class TicketBooking : ITicketBooking
    {
        public SearchListModels GetSearchList(string SourceID, string DestinationID, string JourneyDate, string ReturnDate)
        {
            SearchListModels models = new SearchListModels();

            try
            {

                SqlParameter[] arParms = new SqlParameter[]
                    {
                        new SqlParameter("@SourceID",SourceID),
                        new SqlParameter("@DestinationID",DestinationID),
                        new SqlParameter("@JourneyDate",JourneyDate),
                        new SqlParameter("@Mode", "GetSearchResult"),
                    };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_GetSearchResult", arParms);

                List<SeatModel> _List = new List<SeatModel>();
                _List.Add(new SeatModel
                {

                });
                for (int i = 1; i <= 42; i++)
                {
                    _List.Add(new SeatModel
                    {
                        isFemale = false,
                        IsSold = false,
                        CssClass = "SeatBirth",
                        SeatNo = i.ToString(),
                        SeatPrice = "9000",
                        SeatDiscount = "50"
                    });
                }




                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        models.BusList.Add(new BusModels
                        {

                            RouteID = Convert.ToInt32(dr["ID"]),
                            BusName = dr["BusName"].ToString(),
                            Source = dr["Source"].ToString(),
                            Destination = dr["Destination"].ToString(),
                            Start_Time = dr["Start_Time"].ToString(),
                            End_Time = dr["End_Time"].ToString(),
                            Travel_Time = dr["TravelTime"].ToString(),
                            SeatLeft = "38",
                            Total_Fare = dr["TicketPrice"].ToString(),
                            Discount = dr["Discount"].ToString(),
                            SeatList = _List,
                            Lower_SeatList_R1 = _List,
                            Lower_SeatList_R2 = _List,
                            Lower_SeatList_R3 = _List,
                            Lower_SeatList_R4 = _List,
                        });

                    }

                }
            }
            catch (Exception ex)
            {

            }

            return models;


        }
        public SearchListModels GetBusSeat(int RouteID, string JourneyDate, string SourceID, string DestinationID,string SeatTempate)
        {
            SearchListModels models = new SearchListModels();


            DataSet ds = new DataSet();

            try
            {

                SqlParameter[] arParms = new SqlParameter[]
             {
                        new SqlParameter("@RouteID",RouteID),
                        new SqlParameter("@SourceID",SourceID),
                        new SqlParameter("@DestinationID",DestinationID),
                        new SqlParameter("@JourneyDate",CommonFunction.ConvertToDateTime( JourneyDate,"dd/MM/yyyy")),
                        new SqlParameter("@Mode", "GetBusTicket"),
             };
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveTicket", arParms);


                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    string TicketFare = ds.Tables[0].Rows[0]["TicketPrice"].ToString();
                    string Discount = ds.Tables[0].Rows[0]["Discount"].ToString();

                    List<SeatModel> _List = new List<SeatModel>();
                    SeatModel _SModel = new SeatModel();

                    _List.Add(new SeatModel
                    {
                        isFemale = false,

                    });


                    for (int i = 0; i < 43; i++)
                    {

                        _SModel = CheckSeatStatus((i + 1).ToString(), ds);

                        _List.Add(new SeatModel
                        {
                            isFemale = false,
                            CssClass = _SModel.IsSold == true ? SeatTempate+"_SeatHold" : SeatTempate +"_SeatBirth",
                            IsSold = _SModel.IsSold,
                            SeatNo = i.ToString(),
                            SeatPrice = TicketFare,
                            SeatDiscount = Discount
                        });
                    }

                    models.BusList.Add(new BusModels
                    {
                        RouteID = RouteID,
                        SeatList = _List,
                    });

                    // Add Pickup Point
                    if (ds != null && ds.Tables[2].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ds.Tables[2].Rows[0]["Point1"].ToString()))
                        {
                            models.PickUpPointList.Add(new SelectListItem
                            {
                                Value = "1",
                                Text = ds.Tables[2].Rows[0]["Point1"].ToString()
                            });
                            models.PickUpPointList.Add(new SelectListItem
                            {
                                Value = "2",
                                Text = ds.Tables[2].Rows[0]["Point2"].ToString()
                            });
                            models.PickUpPointList.Add(new SelectListItem
                            {
                                Value = "3",
                                Text = ds.Tables[2].Rows[0]["Point3"].ToString()
                            });
                            models.PickUpPointList.Add(new SelectListItem
                            {
                                Value = "4",
                                Text = ds.Tables[2].Rows[0]["Point4"].ToString()
                            });
                        }

                    }


                    // Add Drop Point
                    if (ds != null && ds.Tables[3].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ds.Tables[3].Rows[0]["Point1"].ToString()))
                        {
                            models.DropPointList.Add(new SelectListItem
                            {
                                Value = "1",
                                Text = ds.Tables[3].Rows[0]["Point1"].ToString()
                            });
                            models.DropPointList.Add(new SelectListItem
                            {
                                Value = "2",
                                Text = ds.Tables[3].Rows[0]["Point2"].ToString()
                            });
                            models.DropPointList.Add(new SelectListItem
                            {
                                Value = "3",
                                Text = ds.Tables[3].Rows[0]["Point3"].ToString()
                            });
                            models.DropPointList.Add(new SelectListItem
                            {
                                Value = "4",
                                Text = ds.Tables[3].Rows[0]["Point4"].ToString()
                            });
                        }

                    }








                }



            }
            catch (Exception ex)
            {

            }
            return models;

        }



        private SeatModel CheckSeatStatus(string SeatNo, DataSet ds)
        {
            SeatModel models = new SeatModel();

            DataRow[] dr = ds.Tables[1].Select("SeatNo=" + SeatNo);

            if (dr.Length > 0)
            {
                models.IsSold = true;

            }







            return models;


        }


        public ResponseModels SaveTicket(TicketBookingModels models)
        {

            ResponseModels _respModel = new ResponseModels();
            try
            {
                string Qry = "";

                foreach (var l in models.PassengerList)
                {
                    Qry = Qry + @"INSERT INTO [tbl_PassengerDetails]
           ([TicketNo]
           ,[Name]
           ,[Gender]
           ,[Age]
           ,[SeatNo]
           ,[BookingID])
            VALUES
           ('" + models.TicketNo + "','" + l.Name + "','" + l.Gender + "'," + l.Age + "," + l.SeatNo + ", 0); ";


                }
                SqlParameter[] arParms = new SqlParameter[]
                  {
                           new SqlParameter("@Name",models.Name),
                           new SqlParameter("@Email",models.Email),
                          new SqlParameter("@SourceID",models.SourceID),
                           new SqlParameter("@DestinationID",models.DestinationID),
                           new SqlParameter("@MobileCountryCode",models.MobileCountryCode),
                           new SqlParameter("@MobileNo",models.MobileNo),
                           new SqlParameter("@Source",models.Source),
                           new SqlParameter("@Destination",models.Destination),
                           new SqlParameter("@JourneyDate",CommonFunction.ConvertToDateTime( models.JourneyDate,"dd/MM/yyyy")),
                           new SqlParameter("@TicketNo",models.TicketNo),
                           new SqlParameter("@TotalAmount",models.TotalAmount),
                           new SqlParameter("@RouteID",models.RouteID),
                           new SqlParameter("@PassengerDetails",Qry),
                           new SqlParameter("@TravelInsuranceAmount",models.TravelInsuranceAmount),
                           new SqlParameter("@IsTravelInsurance",models.IsTravelInsurance),
                           new SqlParameter("@GSTAmount",models.GSTAmount),
                           new SqlParameter("@TotalPayableAmount",models.TotalPayableAmount),
                            new SqlParameter("@PickUpPoint",models.PickUpPoint),
                            new SqlParameter("@DropPoint",models.DropPoint),



                           new SqlParameter("@Mode", "SaveTicket")
                  };


                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveTicket", arParms);
                _respModel.Status = ResponseStatus.Success;




            }
            catch (Exception ex)
            {
                _respModel.Status = ResponseStatus.Fail;
            }
            return _respModel;
        }
        public ResponseModels UpdatePaymentStatus(string TicketNo, string PaymentID)
        {
            ResponseModels respModels = new ResponseModels();

            try

            {
                string _Qry = "Update tbl_TicketBookingDetails set  PaymentStatus=1,PaymentID='" + PaymentID + "' WHERE TicketNo='" + TicketNo + "'";
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, _Qry);
                respModels.Result = ResponseStatus.Success;

            }
            catch (Exception ex)
            {
                respModels.Result = ResponseStatus.Fail;
            }
            return respModels;


        }


        public RouteStopageModel GetRootStopage(int RouteID)
        {
            RouteStopageModel models = new RouteStopageModel();

            string _Qry = @" Select RM.SourceDestination SourceName,
RMS.PickUp_Point1_Time STIME1,
RMS.PickUp_Point2_Time STIME2,
RMS.PickUp_Point3_Time STIME3,
RMS.PickUp_Point4_Time STIME4,
RMS.* from tbl_Route_Stoppage_Map  RMS INNER JOIN 
tbl_PickUP_DropPointMaster RM ON RM.ID=RMS.SourceID  WHERE RMS.Route_ID=" + RouteID;

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, _Qry);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    models.StopageList.Add(new RouteStopageModel
                    {
                        SourceName = dr["SourceName"].ToString(),
                        PickUp_Point1_Time = dr["STIME1"].ToString(),
                        PickUp_Point2_Time = dr["STIME2"].ToString(),
                        PickUp_Point3_Time = dr["STIME3"].ToString(),
                        PickUp_Point4_Time = dr["STIME4"].ToString(),
                        StopageMapID = Convert.ToInt32(dr["ID"].ToString())

                    });
                }
            }

            return models;

        }



        public int SaveStopage(int RouteID, int SourceID, string Time1, string Time2, string Time3, string Time4)
        {

            string _Qry = @"INSERT INTO [tbl_Route_Stoppage_Map]
           ([SourceID]
           
           ,[Route_ID]
           ,[PickUp_Point1_Time]
           ,[PickUp_Point2_Time]
           ,[PickUp_Point3_Time]
           ,[PickUp_Point4_Time]
           )
     VALUES (" + SourceID + "," + RouteID + ",'" + Time1 + "','"
        + Time2 + "','"
        + Time3 + "','"
        + Time1 + "')";

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, _Qry); ;
        }


        public int DeleteStopage(int stopageID)
        {
            string _Qry = @"Delete From tbl_Route_Stoppage_Map Where ID=" + stopageID;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, _Qry); ;
        }


        public PrintTicketModels BindTicketForPrint(string TicketNo)
        {
            PrintTicketModels models = new PrintTicketModels();

            try
            {

                SqlParameter[] arParms = new SqlParameter[]
                     {

                           new SqlParameter("@TicketNo",TicketNo),
                           new SqlParameter("@Mode", "GetTicketForPrint")
                     };

                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveTicket", arParms);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string PickUpPoint = ds.Tables[0].Rows[0]["PickUpPoint"].ToString();
                    string DropPoint = ds.Tables[0].Rows[0]["DropPoint"].ToString();

                    models.BusName = ds.Tables[0].Rows[0]["BusName"].ToString();
                    models.TicketNo = TicketNo;
                    models.Source = ds.Tables[0].Rows[0]["SourcePoint"].ToString();
                    models.Destination = ds.Tables[0].Rows[0]["DestinationPoint"].ToString();
                    models.JournyStartDate = ds.Tables[0].Rows[0]["JDate"].ToString();

                  //  models.JournyStartTime = ds.Tables[1].Rows[0]["" + PickUpPoint].ToString();

                    models.PickUPPoint = ds.Tables[1].Rows[0]["Point" + PickUpPoint].ToString();
                    models.PickUPPoint_LendMark= ds.Tables[1].Rows[0]["Point" + PickUpPoint + "_LendMark"].ToString();
                    models.PickUPPoint_Address = ds.Tables[1].Rows[0]["Point" + PickUpPoint + "_Address"].ToString();
                   


                    models.DropPoint = ds.Tables[2].Rows[0]["Point" + DropPoint].ToString();
                    models.DropPoint_LendMark = ds.Tables[2].Rows[0]["Point" + DropPoint + "_LendMark"].ToString();
                    models.DropPoint_Address = ds.Tables[2].Rows[0]["Point" + DropPoint + "_Address"].ToString();

                    models.JournyStartTime = ds.Tables[3].Rows[0]["PickUp_Point"+ PickUpPoint +"_Time"].ToString();



                    models.JournyEndTime = ds.Tables[4].Rows[0]["PickUp_Point" + DropPoint + "_Time"].ToString();

                    models.TotalFare = ds.Tables[0].Rows[0]["TotalPayableAmount"].ToString();


                    foreach(DataRow dr in ds.Tables[5].Rows)
                    {


                        models.PassengerList.Add(new PassengerDetails
                        {
                            Name=dr["Name"].ToString(),
                            Age = dr["Age"].ToString(),
                            SeatNo = dr["SeatNo"].ToString(),
                            Gender = dr["Gender"].ToString(),

                        });
                    }





                }
            }
            catch (Exception ex)
            {

            }

            return models;
        }



        public  TicketBookingModels GetTicketBookingList()
        {
            TicketBookingModels models = new TicketBookingModels();

            try
            {


                string _Qry = @"select PD.SourceDestination Source,PD1.SourceDestination Destination, TB.* from tbl_TicketBookingDetails TB Inner Join 
tbl_PickUP_DropPointMaster PD ON PD.ID=TB.SourceID
Inner Join tbl_PickUP_DropPointMaster PD1 ON PD1.ID=TB.DestinationID
";


                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, _Qry);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {


                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        models.TicketList.Add(new TicketBookingModels
                            {
                                Source = dr["Source"].ToString(),
                                Destination = dr["Destination"].ToString(),
                                TicketNo = dr["TicketNo"].ToString(),
                                Name = dr["Name"].ToString(),
                                MobileNo = dr["MobileNo"].ToString(),
                                Email = dr["Email"].ToString(),
                                TotalPayableAmount = dr["TotalPayableAmount"].ToString(),
                                PaymentID = dr["PaymentID"].ToString(),
                               


                            });
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return models;
        }

    }
}

