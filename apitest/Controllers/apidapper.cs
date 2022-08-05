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
            using (var queryable = conectionable.CreateConnection())
            { 
            queryable.Open();                
            var result = queryable.Query("SELECT * from usertesting");
            return result;
            }
        }

        [HttpPost(Name = "Postapidapper")]
        public string Postdata( userdifeine userinto)
        {
            //var nuevovalor = otherData.ToString();
            string respuesta=" ";
            var conectionable = new ConnectionSql();
            using ( var queryable = conectionable.CreateConnection())
            {
                queryable.Open();
                string userInsertuery = "INSERT INTO usertesting (name, email, age, contrasena) VALUES (@Name, @Email, @Age, @Password)";
                int rowsAffected = queryable.Execute(userInsertuery, userinto);
                respuesta = rowsAffected.ToString();
            }
            return respuesta;
        }
    }

    public class userdifeine {
        public int IDkunde { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }

    }
}
    

