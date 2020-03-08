using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanakHolidays.Models;
namespace KanakHolidays.Repository
{
  public  interface IPackage
    {
        List<PackageModels> GetPackagesList(int PackageTypeID);
    }
}
