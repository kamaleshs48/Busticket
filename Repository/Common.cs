using KanakHolidays.Areas.Admin.Models;
using KanakHolidays.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace KanakHolidays.Repository
{
    public class Common : ICommon
    {

        public List<CityModels> GetCityList()
        {
            List<CityModels> _List = new List<CityModels>();
            try
            {


                String Qry = "Select * from tbl_PickUP_DropPointMaster";

                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, Qry);

                if(ds!=null && ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        _List.Add(new CityModels
                        {
                             Cityname = dr["SourceDestination"].ToString(),
                            address1 = dr["Point1_Address"].ToString(),
                            address2 = dr["Point2_Address"].ToString(),
                            ID = dr["Id"].ToString()

                        }); 
                    }
                }


            }
            catch (Exception ex)
            {

            }


            return _List;
        }
        public ResponseModels Add_Coach(Coachmaster models, string status)
        {
            ResponseModels _Rsp = new ResponseModels();


            if (status == "49" || status == "41")
            {
                try
                {


                    string Qry = @" INSERT INTO[dbo].[tbl_Coachmaster]
           ([Coach],[Seat_Quantity]
            ,[Index_1],[Index_2],[Index_3],[Index_4],[Index_5],[Index_6],[Index_7],[Index_8],[Index_9],[Index_10],[Index_11],[Index_12]
            ,[Index_13],[Index_14],[Index_15],[Index_16],[Index_17],[Index_18],[Index_19],[Index_20],[Index_21],[Index_22],[Index_23],[Index_24]
            ,[Index_25],[Index_26],[Index_27],[Index_28],[Index_29],[Index_30],[Index_31],[Index_32],[Index_33],[Index_34],[Index_35],[Index_36],[Index_37]
            ,[Index_38],[Index_39],[Index_40],[Index_41],[Index_42],[Index_43],[Index_44],[Index_45],[Index_46],[Index_47],[Index_48],[Index_49],[Index_50]
            ,[Index_51],[Index_52],[Index_53],[Index_54],[Index_55],[Index_56],[Index_57],[Index_58],[Index_59],[Index_60])
   
        VALUES
           
            ('" + models.coatch + "','" + status + "','" + models.drop_seat_qty1 + "','" + models.drop_seat_qty2 + "','" + models.drop_seat_qty3 + "','" + models.drop_seat_qty4
                 + "','" + models.drop_seat_qty5 + "','" + models.drop_seat_qty6 + "','" + models.drop_seat_qty7 + "','" + models.drop_seat_qty8
                 + "','" + models.drop_seat_qty9 + "','" + models.drop_seat_qty10 + "','" + models.drop_seat_qty11 + "','" + models.drop_seat_qty12
                 + "','" + models.drop_seat_qty13 + "','" + models.drop_seat_qty14 + "','" + models.drop_seat_qty15 + "','" + models.drop_seat_qty16
                 + "','" + models.drop_seat_qty17 + "','" + models.drop_seat_qty18 + "','" + models.drop_seat_qty19 + "','" + models.drop_seat_qty20
                 + "','" + models.drop_seat_qty21 + "','" + models.drop_seat_qty22 + "','" + models.drop_seat_qty23 + "','" + models.drop_seat_qty24
                 + "','" + models.drop_seat_qty25 + "','" + models.drop_seat_qty26 + "','" + models.drop_seat_qty27 + "','" + models.drop_seat_qty28
                 + "','" + models.drop_seat_qty29 + "','" + models.drop_seat_qty30 + "','" + models.drop_seat_qty31 + "','" + models.drop_seat_qty32
                 + "','" + models.drop_seat_qty33 + "','" + models.drop_seat_qty34 + "','" + models.drop_seat_qty35 + "','" + models.drop_seat_qty36
                 + "','" + models.drop_seat_qty37 + "','" + models.drop_seat_qty38 + "','" + models.drop_seat_qty39 + "','" + models.drop_seat_qty40
                 + "','" + models.drop_seat_qty41 + "','" + models.drop_seat_qty42 + "','" + models.drop_seat_qty43 + "','" + models.drop_seat_qty44
                 + "','" + models.drop_seat_qty45 + "','" + models.drop_seat_qty46 + "','" + models.drop_seat_qty47 + "','" + models.drop_seat_qty48
                 + "','" + models.drop_seat_qty49 + "','" + models.drop_seat_qty50 + "','" + models.drop_seat_qty51 + "','" + models.drop_seat_qty52
                 + "','" + models.drop_seat_qty53 + "','" + models.drop_seat_qty54 + "','" + models.drop_seat_qty55 + "','" + models.drop_seat_qty56
                 + "','" + models.drop_seat_qty57 + "','" + models.drop_seat_qty58 + "','" + models.drop_seat_qty59 + "','" + models.drop_seat_qty60 + "')";

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, Qry);

                    _Rsp.Status = ResponseStatus.Success;

                }

                catch (Exception ex)
                {
                    _Rsp.ErrorMessage = ex.Message;
                    _Rsp.Status = ResponseStatus.Fail;

                }

            }


            _Rsp.Status = ResponseStatus.Fail;


            return _Rsp;
        }


        public ResponseModels Quick_search(IndexModel models)
        {
            ResponseModels _Rsp = new ResponseModels();

            try
            {
                string Qry = @"INSERT INTO [dbo].[tbl_QuickQuery]
           ([name]
           ,[email]
           ,[mobile]
           ,[subject]
           ,[message]) values ('" + models.Quick_Name + "','" + models.Quick_Email + "','" + models.Quick_Mobile + "','" + models.Quick_Subject + "','" + models.Quick_Message + "')";
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, Qry);
            }
            catch (Exception ex)
            {
                var e = ex;
                _Rsp.Status = ResponseStatus.Fail;
            }

            return _Rsp;
        }
        public ResponseModels Addcity(CityModels models)
        {

            ResponseModels _Rsp = new ResponseModels();

            try
            {
                string Qry = @"INSERT INTO [dbo].[tbl_PickUP_DropPointMaster]
           ([SourceDestination]
           ,[Point1]
           ,[Point2]
           ,[Point3]
           ,[Point4]
           ,[Point1_LendMark]
           ,[Point2_LendMark]
           ,[Point3_LendMark]
           ,[Point4_LendMark]
           ,[Point1_Address]
           ,[Point2_Address]
           ,[Point3_Address]
           ,[Point4_Address])
     VALUES ('" + models.address1 + "','" + models.address2 + "','" + models.address3 + "','" + models.address4 + "','" + models.landmark1 + "','" + models.landmark2 + "','" + models.landmark3 + "','" + models.landmark4 + "','" + models.address1 + "','" + models.address2 + "','" + models.address3 + "','" + models.address4 + "') ";

                int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, Qry);
                _Rsp.Status = ResponseStatus.Success;
            }
            catch (Exception ec)
            {
                _Rsp.ErrorMessage = ec.Message;
                _Rsp.Status = ResponseStatus.Fail;
            }

            return _Rsp;


        }

        public IndexModel BindHomePage()
        {
            IndexModel models = new IndexModel();

            string Qry = @"
Select Top 12 * from tbl_Hotel_Master Order by ID desc
Select Top 12 * from tbl_Package Order by ID desc;
Select  * from tbl_PickUP_DropPointMaster Order by SourceDestination
";


            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, Qry);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    models.HotelList.Add(new HotelViewModels
                    {
                        HotelID = dr["ID"].ToString(),
                        HotelImage = dr["Pic1"].ToString(),
                        HotelName = dr["Hotel"].ToString(),
                        HotelPrice = dr["Season_Cost"].ToString()
                    });

                }
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    models.PackageList.Add(new PackageViewModels
                    {
                        PackageID = dr["ID"].ToString(),
                        PackageDescription = dr["Description"].ToString(),
                        PackageImage = dr["Pic1"].ToString(),
                        PackageName = dr["Package_Name"].ToString(),
                        PackagePrice = dr["Season_Cost"].ToString()
                    });

                }


                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    models.SourceList.Add(new SelectListItem
                    {
                        Value = dr["ID"].ToString(),
                        Text = dr["SourceDestination"].ToString(),
                    });

                }


            }

            return models;
        }

        public ResponseModels AddHotel(HotelModels models)
        {
            ResponseModels resp = new ResponseModels();


            try
            {
                SqlParameter[]arParms = new SqlParameter[]
           {
                new SqlParameter("@Hotel", models.HotelName),
                new SqlParameter("@City", models.City),
                new SqlParameter("@Address", models.Address),
                new SqlParameter("@Type", models.Type),
                new SqlParameter("@Descriptions", models.Descriptions),
                new SqlParameter("@Pic1", models.Pic1),
                new SqlParameter("@Pic2", models.Pic2),
                new SqlParameter("@Pic3", models.Pic3),
                new SqlParameter("@Pic4", models.Pic4),
                new SqlParameter("@Pic5", models.Pic5),
                new SqlParameter("@Season_Cost", models.Season_Cost),
                new SqlParameter("@Off_Season_Cost", models.Off_Season_Cost),
                new SqlParameter("@Festival_Days_Cost", models.Festival_Days_Cost),
                new SqlParameter("@HotelID", models.HotelID),
                new SqlParameter("@Mode", models.ActionMode),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_HotelManagment", arParms);
                resp.Status = ResponseStatus.Success;
                resp.ResultDS = ds;


            }
            catch (Exception ex)
            {
                resp.Status = ResponseStatus.Fail;
                resp.ErrorMessage = ex.Message;
            }
            return resp;

        }
        public ResponseModels SaveEnquery(EnquiryModels models)
        {
            ResponseModels resp = new ResponseModels();
            try
            {
                SqlParameter[] arParms = new SqlParameter[]
               {
                new SqlParameter("@Name", models.Name),
                new SqlParameter("@Email", models.Email),
                new SqlParameter("@MobileNo", models.MobileNo),
                new SqlParameter("@CheckIn", models.CheckIn),
                new SqlParameter("@CheckOut", models.CheckOut),
                new SqlParameter("@EnquiryFor", models.EnquiryFor),
                new SqlParameter("@IPAddress", models.IPAddress),
                new SqlParameter("@PropertyID",models.PropertyID),
                new SqlParameter("@Mode", "AddEnquiry"),
                };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_EnquiryManagment", arParms);
                resp.Status = ResponseStatus.Success;
                resp.ResultDS = ds;


            }
            catch (Exception ex)
            {
                resp.Status = ResponseStatus.Fail;
                resp.ErrorMessage = ex.Message;
            }
            return resp;

        }


        public ResponseModels SavePackage(PackageModels models)
        {
            ResponseModels resp = new ResponseModels();
            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {
                 new SqlParameter("@PackageID", models.PackageID),
               new SqlParameter("@Package_Name", models.Package_Name),
                new SqlParameter("@Duration", models.Duration),
                new SqlParameter("@Bus_Type", models.Bus_Type),
                new SqlParameter("@Description", models.Description),
                new SqlParameter("@Season_Cost", models.Season_Cost),
                new SqlParameter("@Off_Season_Cost", models.Off_Season_Cost),
                new SqlParameter("@Festivals_Days_Cost", models.Festivals_Days_Cost),
                new SqlParameter("@Pickup_Point", models.Pickup_Point),
                new SqlParameter("@Drop_Point", models.Drop_Point),
                new SqlParameter("@Covered_Destinations", models.Covered_Destinations),
                new SqlParameter("@Schedules", models.Schedules),
                new SqlParameter("@Inclusions", models.Inclusions),
                new SqlParameter("@Exclusions", models.Exclusions),
                new SqlParameter("@Mode", models.ActionMode),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_PackageManagment", arParms);
                resp.Status = ResponseStatus.Success;
                resp.ResultDS = ds;


            }
            catch (Exception ex)
            {
                resp.Status = ResponseStatus.Fail;
                resp.ErrorMessage = ex.Message;
            }
            return resp;

        }



        public List<HotelModels> HotelList()
        {
            List<HotelModels> _list = new List<HotelModels>();


            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {

                new SqlParameter("@Mode", "HotelList"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_HotelManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _list.Add(new HotelModels
                        {

                            HotelID = dr["ID"].ToString(),
                            HotelName = dr["Hotel"].ToString(),
                            City = dr["City"].ToString(),
                            Address = dr["Address"].ToString(),
                            Type = dr["Type"].ToString(),
                            Descriptions = dr["Descriptions"].ToString(),
                            Season_Cost = dr["Season_Cost"].ToString(),
                            Off_Season_Cost = dr["Off_Season_Cost"].ToString(),
                            Festival_Days_Cost = dr["Off_Season_Cost"].ToString(),
                        });
                    }
                }





            }
            catch (Exception ex)
            {

            }


            return _list;



        }


        public List<PackageModels> PackageList()
        {
            List<PackageModels> _list = new List<PackageModels>();


            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {

                new SqlParameter("@Mode", "PackageList"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_PackageManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _list.Add(new PackageModels
                        {

                            PackageID = dr["ID"].ToString(),
                            Package_Name = dr["Package_Name"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            Bus_Type = dr["Bus_Type"].ToString(),
                            Description = dr["Description"].ToString(),
                            Season_Cost = dr["Season_Cost"].ToString(),
                            Off_Season_Cost = dr["Off_Season_Cost"].ToString(),
                            Festivals_Days_Cost = dr["Festivals_Days_Cost"].ToString(),
                            Pickup_Point = dr["Pickup_Point"].ToString(),
                            Drop_Point = dr["Drop_Point"].ToString(),
                            Covered_Destinations = dr["Covered_Destinations"].ToString(),
                            Schedules = dr["Schedules"].ToString(),
                            Inclusions = dr["Inclusions"].ToString(),
                            Exclusions = dr["Exclusions"].ToString(),

                        });
                    }
                }





            }
            catch (Exception ex)
            {

            }


            return _list;



        }



        public List<EnquiryModels> EnquiryList()
        {
            List<EnquiryModels> _list = new List<EnquiryModels>();


            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {

                new SqlParameter("@Mode", "EnquiryList"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_EnquiryManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _list.Add(new EnquiryModels
                        {

                            Name = dr["Name"].ToString(),
                            Email = dr["Email"].ToString(),
                            MobileNo = dr["MobileNo"].ToString(),
                            EnquiryFor = dr["EnquiryFor"].ToString(),
                            CheckIn = dr["CheckIn"].ToString(),
                            CheckOut = dr["CheckOut"].ToString(),
                            IPAddress = dr["IPAddress"].ToString(),
                            EnquiryDate = dr["CreateDate"].ToString(),


                        });
                    }
                }





            }
            catch (Exception ex)
            {

            }


            return _list;

        }


        public HotelModels BindHotelDetails(int HotelID)
        {
            HotelModels models = new HotelModels();

            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {
                new SqlParameter("@HotelID",HotelID),
                new SqlParameter("@Mode", "HotelDetailsByID"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_HotelManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    models.HotelID = ds.Tables[0].Rows[0]["ID"].ToString();
                    models.HotelName = ds.Tables[0].Rows[0]["Hotel"].ToString();
                    models.City = ds.Tables[0].Rows[0]["City"].ToString();
                    models.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    models.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                    models.Descriptions = ds.Tables[0].Rows[0]["Descriptions"].ToString();
                    models.Season_Cost = ds.Tables[0].Rows[0]["Season_Cost"].ToString();
                    models.Off_Season_Cost = ds.Tables[0].Rows[0]["Off_Season_Cost"].ToString();
                    models.Festival_Days_Cost = ds.Tables[0].Rows[0]["Off_Season_Cost"].ToString();


                    models.Pic1 = ds.Tables[0].Rows[0]["PIC1"].ToString();
                    models.Pic2 = ds.Tables[0].Rows[0]["PIC2"].ToString();
                    models.Pic3 = ds.Tables[0].Rows[0]["PIC3"].ToString();
                    models.Pic4 = ds.Tables[0].Rows[0]["PIC4"].ToString();
                    models.Pic5 = ds.Tables[0].Rows[0]["PIC5"].ToString();


                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC1"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC2"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC3"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC4"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC5"].ToString());


                }


            }
            catch (Exception ex)
            {

            }
            return models;
        }

        public ResponseModels UpdateHotel(HotelModels models)
        {

            ResponseModels resp = new ResponseModels();


            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {
                new SqlParameter("@Hotel", models.HotelName),
                new SqlParameter("@City", models.City),
                new SqlParameter("@Address", models.Address),
                new SqlParameter("@Type", models.Type),
                new SqlParameter("@Descriptions", models.Descriptions),
                new SqlParameter("@Pic1", models.Pic1),
                new SqlParameter("@Pic2", models.Pic2),
                new SqlParameter("@Pic3", models.Pic3),
                new SqlParameter("@Pic4", models.Pic4),
                new SqlParameter("@Pic5", models.Pic5),
                new SqlParameter("@Season_Cost", models.Season_Cost),
                new SqlParameter("@Off_Season_Cost", models.Off_Season_Cost),
                new SqlParameter("@Festival_Days_Cost", models.Festival_Days_Cost),
                new SqlParameter("@Mode", "UpdateHotel"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_HotelManagment", arParms);
                resp.Status = ResponseStatus.Success;
                resp.ResultDS = ds;


            }
            catch (Exception ex)
            {
                resp.Status = ResponseStatus.Fail;
                resp.ErrorMessage = ex.Message;
            }
            return resp;
        }


        public PackageModels BindPackage(int PackageID)
        {
            PackageModels models = new PackageModels();

            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {
                new SqlParameter("@PackageID",PackageID),
                new SqlParameter("@Mode", "PackageDetailsByID"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_PackageManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    models.PackageID = ds.Tables[0].Rows[0]["ID"].ToString();
                    models.Package_Name = ds.Tables[0].Rows[0]["Package_Name"].ToString();
                    models.Duration = ds.Tables[0].Rows[0]["Duration"].ToString();
                    models.Bus_Type = ds.Tables[0].Rows[0]["Bus_Type"].ToString();
                    models.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                    models.Season_Cost = ds.Tables[0].Rows[0]["Season_Cost"].ToString();
                    models.Off_Season_Cost = ds.Tables[0].Rows[0]["Off_Season_Cost"].ToString();
                    models.Festivals_Days_Cost = ds.Tables[0].Rows[0]["Festivals_Days_Cost"].ToString();
                    models.Pickup_Point = ds.Tables[0].Rows[0]["Pickup_Point"].ToString();
                    models.Drop_Point = ds.Tables[0].Rows[0]["Drop_Point"].ToString();
                    models.Covered_Destinations = ds.Tables[0].Rows[0]["Covered_Destinations"].ToString();
                    models.Schedules = ds.Tables[0].Rows[0]["Schedules"].ToString();
                    models.Inclusions = ds.Tables[0].Rows[0]["Inclusions"].ToString();
                    models.Exclusions = ds.Tables[0].Rows[0]["Exclusions"].ToString();
                    models.Pic1 = ds.Tables[0].Rows[0]["PIC1"].ToString();
                    models.Pic2 = ds.Tables[0].Rows[0]["PIC2"].ToString();
                    models.Pic3 = ds.Tables[0].Rows[0]["PIC3"].ToString();
                    models.Pic4 = ds.Tables[0].Rows[0]["PIC4"].ToString();
                    models.Pic5 = ds.Tables[0].Rows[0]["PIC5"].ToString();
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC1"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC2"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC3"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC4"].ToString());
                    models.ImageList.Add(ds.Tables[0].Rows[0]["PIC5"].ToString());

                }


            }
            catch (Exception ex)
            {

            }
            return models;
        }


        public ResponseModels AddRoute(RouteModels models)
        {
            ResponseModels _respModels = new ResponseModels();

            try
            {
                SqlParameter[] arParms = new SqlParameter[]
                {
                new SqlParameter("@BusName",  models.BusName ),
                new SqlParameter("@Source",  models.Source ),
                 new SqlParameter("@SourceID",  models.SourceID ),
                new SqlParameter("@Destination", models.Destination  ),
                  new SqlParameter("@DestinationID", models.DestinationID  ),
                new SqlParameter("@Start_Time", models.Start_Time ),
                new SqlParameter("@End_Time", models.End_Time  ),
                new SqlParameter("@TravelTime", models.TravelTime ),
                new SqlParameter("@TotalSeat", models.TotalSeat ),
                new SqlParameter("@TicketPrice", models.TicketPrice ),
                new SqlParameter("@Discount", models.Discount  ),
                new SqlParameter("@Travel_Frequency", models.Travel_Frequency  ),
                new SqlParameter("@StartDate",CommonFunction. ConvertToDateTime(models.StartDate ,"dd/MM/yyyy") ),
                new SqlParameter("@EndDate", CommonFunction. ConvertToDateTime(models.EndDate ,"dd/MM/yyyy") ),
                new SqlParameter("@RouteID",models.RouteID),
                new SqlParameter("@Mode", "AddRoute"),
                };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_RouteManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    _respModels.Status = ResponseStatus.Success;
                }
            }
            catch (Exception ex)
            {
                _respModels.Status = ResponseStatus.Fail;

            }
            return _respModels;
        }

        public RouteModels BindRoute(int RouteID)
        {
            RouteModels models = new RouteModels();

            try
            {
                SqlParameter[] arParms = new SqlParameter[]
           {
                new SqlParameter("@PackageID",RouteID),
                new SqlParameter("@Mode", "RouteDetailsByID"),
           };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_RouteManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    models.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                    models.Destination = ds.Tables[0].Rows[0]["Destination"].ToString();
                    models.Start_Time = ds.Tables[0].Rows[0]["Start_Time"].ToString();
                    models.End_Time = ds.Tables[0].Rows[0]["End_Time"].ToString();
                    models.TravelTime = ds.Tables[0].Rows[0]["TravelTime"].ToString();
                    models.TotalSeat = ds.Tables[0].Rows[0]["TotalSeat"].ToString();
                    models.TicketPrice = ds.Tables[0].Rows[0]["TicketPrice"].ToString();
                    models.Discount = ds.Tables[0].Rows[0]["Discount"].ToString();
                    models.Travel_Frequency = ds.Tables[0].Rows[0]["Travel_Frequency"].ToString();
                    models.StartDate = ds.Tables[0].Rows[0]["StartDate"].ToString();
                    models.EndDate = ds.Tables[0].Rows[0]["EndDate"].ToString();
                    models.IsActive = ds.Tables[0].Rows[0]["IsActive"].ToString() == "True" ? true : false;


                }
            }
            catch (Exception ex)
            {

            }
            return models;
        }
        public List<RouteModels> RouteList()
        {
            List<RouteModels> models = new List<RouteModels>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[]
                   {

                        new SqlParameter("@Mode", "RouteList"),
                   };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_RouteManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        models.Add(new RouteModels
                        {
                            RouteID = Convert.ToInt32(dr["ID"].ToString()),
                            SourceID = Convert.ToInt32(dr["SourceID"].ToString()),
                            DestinationID = Convert.ToInt32(dr["DestinationID"].ToString()),
                            BusName = dr["BusName"].ToString(),
                            Source = dr["Source"].ToString(),
                            Destination = dr["Destination"].ToString(),
                            Start_Time = dr["Start_Time"].ToString(),
                            End_Time = dr["End_Time"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),

                        });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return models;
        }


        public List<SelectListItem> GetSourceList()
        {
            List<SelectListItem> _List = new List<SelectListItem>();
            string Qry = @" Select  * from tbl_PickUP_DropPointMaster Order by SourceDestination ";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, Qry);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _List.Add(new SelectListItem
                    {
                        Value = dr["ID"].ToString(),
                        Text = dr["SourceDestination"].ToString(),
                    });
                }
            }
            return _List;
        }

        public ResponseModels Show_TableCoach(string Id = null, string del = null)
        {
            throw new NotImplementedException();
        }

        public CityModels BindCityModelsByID(string CityID)
        {
            CityModels models = new CityModels();
            string Qry = "Select * from tbl_PickUP_DropPointMaster where Id='"+ CityID + "'";

            DataSet ds= SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, Qry);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                models.Cityname = ds.Tables[0].Rows[0]["SourceDestination"].ToString();
                models.place1 = ds.Tables[0].Rows[0]["Point1"].ToString();
                models.place2 = ds.Tables[0].Rows[0]["Point2"].ToString();
                models.place3 = ds.Tables[0].Rows[0]["Point3"].ToString();
                models.place4 = ds.Tables[0].Rows[0]["Point4"].ToString();
                models.landmark1 = ds.Tables[0].Rows[0]["Point1_LendMark"].ToString();
                models.landmark2 = ds.Tables[0].Rows[0]["Point2_LendMark"].ToString();
                models.landmark3 = ds.Tables[0].Rows[0]["Point3_LendMark"].ToString();
                models.landmark4 = ds.Tables[0].Rows[0]["Point4_LendMark"].ToString();
                models.address1 = ds.Tables[0].Rows[0]["Point1_Address"].ToString();
                models.address2 = ds.Tables[0].Rows[0]["Point2_Address"].ToString();
                models.address3 = ds.Tables[0].Rows[0]["Point3_Address"].ToString();
                models.address4 = ds.Tables[0].Rows[0]["Point4_Address"].ToString();
            }

                return models;
        }
    }

}