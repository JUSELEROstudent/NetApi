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
        public IActionResult Postdata(login sesionuser)//se responde una clase login MIENTRASTANTO
        {
            //var nuevovalor = otherData.ToString();
            var respuesta = new List<dynamic>();
            var conectionable = new ConnectionSql();
            using (var queryable = conectionable.CreateConnection())
            {

                queryable.Open();
                string loginString = "SELECT * FROM usertesting WHERE (name = @User OR email = @user) AND contrasena = @Password";
                //string loginString = "SELECT * FROM usertesting ";
                var rowsAffected = queryable.Query(loginString, sesionuser).ToList();
                respuesta = rowsAffected.Count() > 0 ? rowsAffected : respuesta.ToList();
                if (respuesta.Count > 0)
                {
                    var token = TokenGenerator.GenerateTokenJwt(rowsAffected[0].userId);
                    return Ok(token);
                } else
                {
                    return BadRequest(new { error = "no idea", cargo = "la chongada" });
                }
            }
        }
        [HttpGet(Name = "GetInnerlogin")]
        public IActionResult Getdata()//se responde una clase login MIENTRASTANTO
        {
            //var nuevovalor = otherData.ToString();
            var respuesta = new List<dynamic>();
            var conectionable = new ConnectionSql();
            using (var queryable = conectionable.CreateConnection())
            {

                queryable.Open();
                string loginString = "SELECT * FROM usertesting WHERE (name = @User OR email = @user) AND contrasena = @Password";
                var rowsAffected = queryable.Query(loginString, ).ToList();
                respuesta = rowsAffected.Count() > 0 ? rowsAffected : respuesta.ToList();
                if (respuesta.Count > 0)
                {
                    var token = TokenValidationHandler.TryRetrieveToken(Request, )
                    return Ok(token);
                }
                else
                {
                    return BadRequest(new { error = "no idea", cargo = "la chongada" });
                }
            }
        }
    }

    public class login { 
    
        public string User { get; set; }
        public string Password { get; set; }
    }
}
