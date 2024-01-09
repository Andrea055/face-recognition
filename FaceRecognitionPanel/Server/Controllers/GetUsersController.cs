using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using face_recognition.Shared;
using System.Security.Permissions;
using DBContext;

namespace face_recognition.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUsersController : ControllerBase
    {
        
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public List<Utenti> Get([FromQuery] string token){
            var db = new FaceContext();
            List<Utenti> vuota = new List<Utenti>();
            if (token == Variables.Token)
            {
                Console.WriteLine("token ok");
                List<Utenti> all_utenti = db.Utenti.ToList();
                return all_utenti;
            }else{
                Console.WriteLine("token invalido");
                return vuota;
            }
        }
    }
}