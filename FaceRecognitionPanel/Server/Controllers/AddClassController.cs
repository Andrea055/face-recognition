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
    public class AddClassController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public string Get([FromQuery] string token, [FromQuery] string name_class){
            var db = new FaceContext();
            if(token == Variables.Token){
                if(name_class!=""){
                    Classi classe = db.Classi.FirstOrDefault(u => u.Sezione == name_class);
                    if(classe==null){
                        db.Add(new Classi{ Sezione=name_class });
                        db.SaveChanges();
                        return "Class added";
                    }else{
                        return "The " + name_class + " class already exists";
                    }
                }else{
                    return "Invalid class name";
                }
            }else{
                return "Invalid token";
            }
        }
    }
}