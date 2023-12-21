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
    public class DeleteClassController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public string Get([FromQuery] string token, [FromQuery] int id){
            var db = new FaceContext();
            if(token == Variables.Token){
                // Class classe = db.Classes.FirstOrDefault(u => u.ClassId == id);
                // db.Classes.Remove(classe);
                // db.SaveChanges();
                // return "Class " + classe.ClassName + " deleted";

                // rimuovi tutte le classi
                var allClasses = db.Classi.ToList();
                foreach(var classe in allClasses){
                    db.Classi.Remove(classe);
                }
                db.SaveChanges();
                return "All classes deleted";
            }else{
                return "Invalid API token";
            }
        }
    }
}