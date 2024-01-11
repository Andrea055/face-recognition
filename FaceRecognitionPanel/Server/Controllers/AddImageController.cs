using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using face_recognition.Shared;
using DBContext;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Principal;

namespace face_recognition.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddImage : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpPost]
        public JsonResult Post([FromBody] request richiesta) {
            List<immagine> file = richiesta.dataimages;
            string token = richiesta.token;
            string path="";
            string Output = "";
            int code = 213;
            if(token == Variables.Token){
                foreach(immagine f in file){
                    path = "utenti/"+f.user+"/"+f.name;
                    Console.WriteLine(f.name+" -> "+f.user);
                    var fs = System.IO.File.Create(path);
                    fs.Write(f.content, 0, f.content.Length);
                    fs.Close(); 
                }
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