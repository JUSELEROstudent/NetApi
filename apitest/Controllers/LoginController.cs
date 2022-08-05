using apitest.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace apitest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Innerlogin : ControllerBase
    {
        [HttpPost(Name = "PostInnerlogin")]
        public string Postdata(login sesionuser)
        {
            //var nuevovalor = otherData.ToString();
            string respuesta = " ";
            var conectionable = new ConnectionSql();
            using (var queryable = conectionable.CreateConnection())
            {
                queryable.Open();
                string loginString = "SELECT * FROM usertesting WHERE (name = @User OR email = @user) AND contrasena = @Password";
                //string loginString = "SELECT * FROM usertesting ";
                var rowsAffected = queryable.Query(loginString, sesionuser).ToList();
                //if (rowsAffected.Count > 0)
                //{
                //    respuesta = rowsAffected.ToString();
                //}
                //else {
                //    respuesta = " no se consiguio el valor digitado";
                //}
            }
            return respuesta;
        }
    }

    public class login { 
    
        public string User { get; set; }
        public string Password { get; set; }
    }
}
