using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace server_proiect
{
    /// <summary>
    /// Summary description for PCService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    public class MyWebService
    {
        // implementation
    }
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PCService : System.Web.Services.WebService
    {
        [WebMethod]
        public int Insert(PC obj)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                DynamicParameters p = new DynamicParameters();
                p.Add("@PCID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    CPU = obj.CPU,
                    GPU = obj.GPU,
                    RAM = obj.RAM,
                    Storage = obj.Storage,
                    Storage_type = obj.Storage_type,
                    Price = obj.Price,
                    ImageUrl = obj.ImageUrlPC
                });
                int result = db.Execute("sp_PC_Insert", p, commandType: CommandType.StoredProcedure);
                if (result != 0)
                    return p.Get<int>("@PCID");
                return 0;

            }

        }

        [WebMethod]
        public bool Update(PC obj)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_PC_Update", new
                {
                    PCID = obj.PCID,
                    CPU = obj.CPU,
                    GPU = obj.GPU,
                    RAM = obj.RAM,
                    Storage = obj.Storage,
                    Storage_type = obj.Storage_type,
                    Price = obj.Price,
                    ImageUrl = obj.ImageUrlPC
                }, commandType: CommandType.StoredProcedure); 
                return result != 0;
            }
        }

        [WebMethod]
        public List<PC> GetAll()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<PC>("select *from PC_shop", commandType: CommandType.Text).ToList();
            }

        }

        [WebMethod]
        public bool Delete(int PCID)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("delete from PC_shop where PCID = @PCID", new
                {
                    PCID = PCID
                }, commandType: CommandType.Text);
                return result != 0;
            }
        }
    }
}