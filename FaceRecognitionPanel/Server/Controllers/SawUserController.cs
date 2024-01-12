using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using face_recognition.Shared;
using DBContext;

namespace face_recognition.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SawUserController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public JsonResult Get([FromQuery] string token, [FromQuery] int id_utente) {
            var db = new FaceContext();
            string Output = "";
            int code = 200;
            if(token == Variables.Token){
                db.Add(new SawUsers{ id_user=id_utente });
                db.SaveChanges(); /* problema erore non trova tabella Classes */
                errors.TryGetValue(code, out Output);
                return new JsonResult( new { Code = code, msg = Output/* , utenti = Utenti.Users_db */ } );
            }else{
                code = 403;
                errors.TryGetValue(code, out Output);
                return new JsonResult( new { Code = code, msg = Output, Details = "Token non valido" } );
            }
        }
    }
}