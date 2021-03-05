using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class TodosModel
    {
        //(UserId,Id,Title,Completed);
        
        //Abaixo vou definir quem são e o tipo dos dados que vão retornar;
        [JsonProperty("userId")]
        public int userId { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("completed")]
        public bool completed { get; set; }
    }
}
