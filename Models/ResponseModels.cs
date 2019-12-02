using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KanakHolidays.Models
{
    public class ResponseModels
    {
        public string ErrorMessage { get; set; }
        public ResponseStatus Status { get; set; }
        public dynamic Result { get; set; }
        public DataSet ResultDS { get; set; }
    }



    public enum ResponseStatus
    {
        Success,
        Fail
    }


    public class IndexModel
    {

        public List<HotelViewModels> HotelList = new List<HotelViewModels>();
        public List<PackageViewModels> PackageList = new List<PackageViewModels>();
      
        public  string SourceID { get; set; }
        public string DestinationID { get; set; }
        public List<SelectListItem> SourceList = new List<SelectListItem>();
        [Required(ErrorMessage = "Please enter Date.")]
        public string JourneyDate { get; set; }
        public string ReturnDate { get; set; }


        [Required (ErrorMessage ="Please  Enter the name")]
        public string Quick_Name { get; set; }
        [Required(ErrorMessage = "Please  Enter the email")]
        public string Quick_Email { get; set; }
        [Required(ErrorMessage = "Please  Enter the mobile")]
        public string Quick_Mobile { get; set; }
        public string Quick_Subject { get; set; }
        [Required(ErrorMessage = "Please  Enter the message")]
        public string Quick_Message { get; set; }



    }

    public class HotelViewModels
    {

        public string HotelName  {get   ;set;}
        public string HotelImage { get; set; }
        public string HotelID { get; set; }
        public string HotelPrice { get; set; }




    }



    public class PackageViewModels
    {

        public string PackageName { get; set; }
        public string PackageImage { get; set; }
        public string PackageID { get; set; }
        public string PackagePrice { get; set; }
        public string PackageDescription { get; set; }




    }

}