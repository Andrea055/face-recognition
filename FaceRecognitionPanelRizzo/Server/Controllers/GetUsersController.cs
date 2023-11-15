using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using face_recognition.Shared;
using System.Security.Permissions;

namespace face_recognition.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUsersController : ControllerBase
    {
        
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        // [HttpGet]
        // public JsonResult Get([FromQuery] string token){
        //     string Output = "";
        //     if(token == Variables.Token){
        //         errors.TryGetValue(200, out Output);
        //         return new JsonResult( new { code = 200, msg = Output, utenti = Users.Users_db } );
        //     }else{
        //         errors.TryGetValue(403, out Output);
        //         return new JsonResult( new { code = 403, msg = Output, Details = "Token non valido" } );
        //     }
        // }

        [HttpGet]
        public JsonResult Get([FromQuery] string token){
            string output = "";
            int code = 200;
            List<string> utenti_db = new List<string>(); // Cambiato da array a List<string>
            string[] list = Directory.GetDirectories("utenti");

            foreach (var dir in list)
            {
                utenti_db.Add(Path.GetFileName(dir)); // Usato il metodo Add per aggiungere elementi alla lista
            }
            utenti_db.Sort();
            string[] utenti_array = utenti_db.ToArray();

            if (token == Variables.Token)
            {
                errors.TryGetValue(code, out output);
                return new JsonResult(new { Code = code, msg = output, utenti = utenti_array });
            }
            else
            {
                code = 403;
                errors.TryGetValue(code, out output);
                return new JsonResult(new { Code = code, msg = output, Details = "Token non valido" });
            }
        }
    }
}