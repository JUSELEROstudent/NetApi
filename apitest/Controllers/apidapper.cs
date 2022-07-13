using apitest.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace apitest.Controllers
{


    [ApiController]
        [Route("api/[controller]")]
        public class apidapper : ControllerBase
        {
            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
             };

            

            [HttpGet(Name = "Getapidapper")]
            public object Getdata()
            {
                var conectionable = new ConnectionSql();
                using (IDbConnection queryable = conectionable.CreateConnection())
                { 
                queryable.Open();                
                var result = queryable.Query("SELECT * from KundeProfile");
                return result;
                }
            }

        [HttpPost(Name = "Postapidapper")]
        public object Postdata( userdifeine userinto)
        {
            //var nuevovalor = otherData.ToString();
            
            return Ok(new { nombre="postMethos", codigo=200});
        }
    }

    public class userdifeine {
        public int IDkunde { get; set; } 
        public string KundeNmae { get; set; }
        public string KUndeEmail { get; set; }
        public int KundeTel { get; set; }
        public string KundeRole { get; set; }

    }
}
    

