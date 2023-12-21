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
    public class DeleteUserController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public string Get([FromQuery] string token, [FromQuery] int id){
            var db = new FaceContext();
            if(token == Variables.Token){
                Utenti utente = db.Utenti.FirstOrDefault(u => u.Id == id);
                string path = "utenti/" + utente.Nome + "_" + utente.Cognome;
                if(Directory.Exists(path)){
                    Directory.Delete(path);
                }
                db.Utenti.Remove(utente);
                db.SaveChanges();
                return "User " + utente.Nome + " deleted";
            }else{
                return "Invalid API token";
            }
        }
    }
}