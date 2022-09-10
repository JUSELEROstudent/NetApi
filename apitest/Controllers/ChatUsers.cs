using Microsoft.AspNetCore.Mvc;
using apitest.Services;
using Dapper;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace apitest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatUsers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFriends()
        {            
            var stream = HttpContext.Request.Headers.Authorization.ToString();
            var handler = new JwtSecurityTokenHandler();
            var stream2 = stream.Remove(0, 7);
            var jsonToken = handler.ReadToken(stream2);
            var tokenS = jsonToken as JwtSecurityToken;
            var GetToUser = tokenS.Payload["unique_name"];
            var conectionable = new ConnectionSql();
            using (var queryable = conectionable.CreateConnection())
            {
                queryable.Open();
                string userInsertuery = "SELECT userId, name  FROM usertesting";
                var rowsAffected = queryable.Query<responsepic>(userInsertuery).ToList();
                return Ok(rowsAffected);
            }
        }
    }

    public class responsepic
    {
        public string name { get; set; }
        
        public int userId { get; set; }

        public string pic { get; set; }
    
    }
}
