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
    public class GetClassesController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public List<Classi> Get([FromQuery] string token){
            var db = new FaceContext();
            List<Classi> vuota = new List<Classi>();
            if (token == Variables.Token)
            {
                List<Classi> all_classes = db.Classi.ToList();

                return all_classes;
            }else{
                return vuota;
            }
        }
    }
}