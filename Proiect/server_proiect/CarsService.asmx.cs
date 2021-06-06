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
    /// Summary description for CarsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CarsService : System.Web.Services.WebService
    {

        [WebMethod]
        public int Insert(Cars obj)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                DynamicParameters p = new DynamicParameters();
                p.Add("@CarID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    Name = obj.Name,
                    Type = obj.Type,
                    Price = obj.Price,
                    Color = obj.Color,
                    ImageUrl = obj.ImageUrl
                });
                int result = db.Execute("sp_Car_Insert", p, commandType: CommandType.StoredProcedure);
                if (result != 0)
                    return p.Get<int>("@CarID");
                return 0;

            }

        }

        [WebMethod]
        public bool Update(Cars obj)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_Car_Update", new
                {
                    CarID = obj.CarID,
                    Name = obj.Name,
                    Type = obj.Type,
                    Price = obj.Price,
                    Color = obj.Color,
                    ImageUrl = obj.ImageUrl
                }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        [WebMethod]
        public List<Cars> GetAll()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Cars>("select *from Cars_shop", commandType: CommandType.Text).ToList();
            }

        }

        [WebMethod]
        public bool Delete(int CarID)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("delete from Cars_shop where CarID = @CarID", new
                {
                    CarID = CarID
                }, commandType: CommandType.Text);
                return result != 0;
            }
        }
    }
}