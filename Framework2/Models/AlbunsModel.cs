using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class AlbunsModel
    {

        //(userId,id,title);

        //Abaixo vou definir quem são e o tipo dos dados que vão retornar;
        [JsonProperty("userId")]
        public int userId { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
