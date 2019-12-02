using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanakHolidays.Areas.Admin.Models;
using KanakHolidays.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KanakHolidays.Repository
{
    public interface ICommon
    {
        ResponseModels AddHotel(HotelModels models);
        ResponseModels SaveEnquery(EnquiryModels models);



        ResponseModels SavePackage(PackageModels models);

        PackageModels BindPackage(int PackageID);

        List<HotelModels> HotelList();
        List<PackageModels> PackageList();
        List<EnquiryModels> EnquiryList();

        List<CityModels> GetCityList();

        HotelModels BindHotelDetails(int HotelID);

        ResponseModels UpdateHotel(HotelModels models);


        ResponseModels AddRoute(RouteModels models);

        RouteModels BindRoute(int RouteID);
        List<RouteModels> RouteList();



        IndexModel BindHomePage();


        List<SelectListItem> GetSourceList();

        ResponseModels Addcity(CityModels models);


        ResponseModels Quick_search(IndexModel models);


        ResponseModels Add_Coach(Coachmaster models,string status);

      ResponseModels Show_TableCoach(string Id=null,string del=null);
        CityModels BindCityModelsByID(string CityID);
    }
}
