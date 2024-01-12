using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using face_recognition.Shared;
using Microsoft.EntityFrameworkCore.Storage;
using System.IO;
using DBContext;

namespace face_recognition.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAllImagesController : ControllerBase
    {
        public Dictionary<int, string> errors= MyErrors.Codes_errors;

        [HttpGet]
        public List<users_images> Get([FromQuery] string token) {
            var db = new FaceContext();
            string path="utenti/";
            string Output = "";
            int code = 200;
            List<users_images> images = new();
            int i=0;
            if(token == Variables.Token){
                // string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "utenti", user);
                string[] users = Directory.GetDirectories(path);
                foreach(string user in users){
                    // nome utente dalla cartella
                    string[] arr = user.Split("/");
                    string utente = arr[arr.Count()-1];
                    arr = utente.Split("_");
                    Console.WriteLine(arr[0]);
                    Console.WriteLine(arr[1]);
                    Utenti dati_utente = db.Utenti.FirstOrDefault(u => u.Nome==arr[0] && u.Cognome==arr[1]);
                    Console.WriteLine("id: ");
                    Console.WriteLine(dati_utente.Id);
                    images.Add( new users_images { user=utente, id_user=dati_utente.Id , files=new() });
                    // immagini utente
                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), user);
                    string[] immagini = Directory.GetFiles(folderPath, "*");
                    foreach(string image in immagini){
                        arr = image.Split("/");
                        var str = System.IO.File.ReadAllBytes(image);
                        images[i].files.Add( new file_data { nome_file=arr[arr.Count()-1], content=str } );
                    }
                    i++;
                    // files.Add( new file { nome_file=arr[arr.Count()-1] });
                }
            }else{
                Console.WriteLine("Token non valido");
            }
            // foreach(file f in files){
            //     Console.WriteLine(f.nome_file);
            // }
            return images;
        }
    }
}