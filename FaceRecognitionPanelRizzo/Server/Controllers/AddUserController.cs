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
    public class AddUserController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public JsonResult Get([FromQuery] string token, [FromQuery] string name, [FromQuery] string surname, [FromQuery] int classe){
            var db = new FaceContext();
            string Output = "";
            int code = 200;
            string path = "utenti/";
            if(token == Variables.Token){
                if(name!=""){
                    string dir = name+"_"+surname;
                    Utenti utente = db.Utenti.FirstOrDefault(u => u.Nome==name && u.Cognome==surname);
                    if(utente==null){
                        code = 210;
                        if(!Directory.Exists(path+dir)){
                            Directory.CreateDirectory(path+dir);
                        }
                        db.Add(new Utenti{ Nome=name, Cognome=surname, Id_classe=classe});
                        db.SaveChanges(); /* problema erore non trova tabella Classes */
                        errors.TryGetValue(code, out Output);
                        return new JsonResult( new { Code = code, msg = Output/* , utenti = Utenti.Users_db */ } );
                    }else{
                        code = 211;
                        errors.TryGetValue(code, out Output);
                        return new JsonResult( new { Code = code, msg = Output/* , utenti = Users.Users_db */ } );
                    }
                }else{
                    code = 212;
                    errors.TryGetValue(code, out Output);
                    return new JsonResult( new { Code = code, msg = Output } );
                }
            }else{
                code = 403;
                errors.TryGetValue(code, out Output);
                return new JsonResult( new { Code = code, msg = Output, Details = "Token non valido" } );
            }
        }
    }
}