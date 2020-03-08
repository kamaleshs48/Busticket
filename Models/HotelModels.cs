using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KanakHolidays.Models;


namespace KanakHolidays.Models
{
    public class HotelModels
    {


        private bool _IsActive = true;
        public string HotelID { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string HotelName { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string City { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string Address { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string Type { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string Descriptions { get; set; }

        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string Season_Cost { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string Off_Season_Cost { get; set; }
        [Required(ErrorMessage = GenericMessage.HotelRequired)]
        public string Festival_Days_Cost { get; set; }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public string ActionMode { get; set; }

        public List<HotelModels> HotelList = new List<HotelModels>();
        public List<string> ImageList = new List<string>();



    }


    public class EnquiryModels
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string IPAddress { get; set; }
        public string EnquiryFor { get; set; }
        public string PropertyID { get; set; }
        public string EnquiryDate { get; set; }
        public List<EnquiryModels> EnquiryList = new List<EnquiryModels>();

    }





    public class PackageModels

    {

      

        private bool _IsActive = true;
        public string PackageID { get; set; }
        public string Package_Title { get; set; }
        public string Package_Code { get; set; }

        public string Package_TypeID { get; set; }
      

        public string Package_Description { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }

        public string Price { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public string ActionMode { get; set; }
        public List<PackageModels> PackageList = new List<PackageModels>();

        public List<string> ImageList = new List<string>();


    }

    public class CityModels
    {[Required(ErrorMessage ="Please Enter City Name")]
        public string Cityname { get; set; }
        [Required]
        public string place1 { get; set; }
        public string drop1 { get; set; }
        public string landmark1 { get; set; }
        public string address1 { get; set; }

        public string place2 { get; set; }
        public string drop2 { get; set; }
        public string landmark2 { get; set; }
        public string address2 { get; set; }

        public string place3 { get; set; }
        public string drop3 { get; set; }
        public string landmark3 { get; set; }
        public string address3 { get; set; }

        public string place4 { get; set; }
        public string drop4 { get; set; }
        public string landmark4 { get; set; }
        public string address4 { get; set; }
        public string ID { get; set; }
        public List<CityModels> CityList = new List<CityModels>();
    }

    public class Coachmaster: ResponseModels
    {
        public string status { get; set; }
        public string coatch { get; set; }
        public string drop_seat_qty0 { get; set; }
        public string drop_seat_qty1 { get; set; }
        public string drop_seat_qty { get; set; }
        public string drop_seat_qty2 { get; set; }
        public string drop_seat_qty3 { get; set; }
        public string drop_seat_qty4 { get; set; }
        public string drop_seat_qty5 { get; set; }
        public string drop_seat_qty6 { get; set; }
        public string drop_seat_qty7 { get; set; }
        public string drop_seat_qty8 { get; set; }
        public string drop_seat_qty9 { get; set; }
        public string drop_seat_qty10 { get; set; }
        public string drop_seat_qty11 { get; set; }
        public string drop_seat_qty12 { get; set; }
        public string drop_seat_qty13 { get; set; }
        public string drop_seat_qty14 { get; set; }
        public string drop_seat_qty15 { get; set; }
        public string drop_seat_qty16 { get; set; }
        public string drop_seat_qty17 { get; set; }
        public string drop_seat_qty18 { get; set; }
        public string drop_seat_qty19 { get; set; }
        public string drop_seat_qty20 { get; set; }


        public string drop_seat_qty21 { get; set; }
        public string drop_seat_qty22 { get; set; }
        public string drop_seat_qty23 { get; set; }
        public string drop_seat_qty24 { get; set; }
        public string drop_seat_qty25 { get; set; }
        public string drop_seat_qty26 { get; set; }
        public string drop_seat_qty27 { get; set; }
        public string drop_seat_qty28 { get; set; }
        public string drop_seat_qty29 { get; set; }
        public string drop_seat_qty30 { get; set; }
        public string drop_seat_qty31 { get; set; }
        public string drop_seat_qty32 { get; set; }
        public string drop_seat_qty33 { get; set; }
        public string drop_seat_qty34 { get; set; }
        public string drop_seat_qty35 { get; set; }
        public string drop_seat_qty36 { get; set; }
        public string drop_seat_qty37 { get; set; }
        public string drop_seat_qty38 { get; set; }
        public string drop_seat_qty39 { get; set; }
        public string drop_seat_qty40 { get; set; }


        public string drop_seat_qty41 { get; set; }
        public string drop_seat_qty42 { get; set; }
        public string drop_seat_qty43 { get; set; }
        public string drop_seat_qty44 { get; set; }
        public string drop_seat_qty45 { get; set; }
        public string drop_seat_qty46 { get; set; }
        public string drop_seat_qty47 { get; set; }
        public string drop_seat_qty48 { get; set; }
        public string drop_seat_qty49 { get; set; }
        public string drop_seat_qty50 { get; set; }
        public string drop_seat_qty51 { get; set; }
        public string drop_seat_qty52 { get; set; }
        public string drop_seat_qty53 { get; set; }
        public string drop_seat_qty54 { get; set; }
        public string drop_seat_qty55 { get; set; }
        public string drop_seat_qty56 { get; set; }
        public string drop_seat_qty57 { get; set; }
        public string drop_seat_qty58 { get; set; }
        public string drop_seat_qty59 { get; set; }
        public string drop_seat_qty60 { get; set; }













    }
}