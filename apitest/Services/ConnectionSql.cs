using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace apitest.Services
{
    public class ConnectionSql : Controller
    {
        public IDbConnection CreateConnection()
        {
            IDbConnection db = new SqlConnection("Server=LAPTOP-GIVPQJIV;Database=Crud;Trusted_Connection=true;Encrypt=False");
            return db;
        }
    }
}
