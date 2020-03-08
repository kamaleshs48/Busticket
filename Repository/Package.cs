using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using KanakHolidays.Models;
namespace KanakHolidays.Repository
{
    public class Package : IPackage
    {
        public List<PackageModels> GetPackagesList(int PackageTypeID)
        {
            List<PackageModels> _list = new List<PackageModels>();
            try
            {
                SqlParameter[] arParms = new SqlParameter[]
                    {
                       new SqlParameter("@Package_Type", PackageTypeID),
                       new SqlParameter("@Mode", "PackageListByPackageType"),
                    };
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_PackageManagment", arParms);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        _list.Add(new PackageModels
                        {

                            PackageID = dr["ID"].ToString(),
                            Package_Title = dr["Package_Title"].ToString(),
                            Package_Description = dr["Description"].ToString(),
                            Package_Code = dr["Package_Code"].ToString(),
                            Line1 = dr["Line1"].ToString(),
                            Line2 = dr["Line2"].ToString(),
                            Line3 = dr["Line2"].ToString(),
                            Line4 = dr["Line4"].ToString(),






                        });
                    }
                }





            }
            catch (Exception ex)
            {

            }


            return _list;
        }

    }
}
