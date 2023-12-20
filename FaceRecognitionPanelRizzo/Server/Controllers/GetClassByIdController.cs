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
    public class GetClassById : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public Classi Get([FromQuery] string token, [FromQuery] int id){
            var db = new FaceContext();
            if (token == Variables.Token)
            {
                Classi classe = db.Classi.FirstOrDefault(u => u.Id == id);
                if (classe != null)
                {
                    return classe;
                }
                else
                {
                    return new Classi();
                }
            }
            else
            {
                return new Classi();
            }
        }
    }
}