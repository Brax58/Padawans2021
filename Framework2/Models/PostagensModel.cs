using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class PostagensModel
    {
   
     //(userId,id,title,body);

        //Abaixo vou definir quem são e o tipo dos dados que vão retornar;
        [JsonProperty("userId")]
        public int userid { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("body")]
        public string body { get; set; }

    }
}
