using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using face_recognition.Shared;
using System.Security.Principal;

namespace face_recognition.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetImagesController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public List<file> Get([FromQuery] string token, [FromQuery] string user) {
            string path="utenti/"+user+"/";
            string Output = "";
            int code = 200;
            List<file> files = new();
            if(token == Variables.Token){
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "utenti", user);
                string[] images = Directory.GetFiles(folderPath, "*.jpg");
                foreach(string image in images){
                    string[] arr = image.Split("/");
                    var str = System.IO.File.ReadAllBytes(image);
                    files.Add( new file { nome_file=arr[arr.Count()-1] });
                }
            }else{
                Console.WriteLine("Token non valido");
            }
            // foreach(file f in files){
            //     Console.WriteLine(f.nome_file);
            // }
            return files;
        }
    }
}