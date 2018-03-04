using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.Model
{
    public class Error
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ModelState")]
        public ModelState ModelState { get; set; }
    }

    public class ModelState
    {
        [JsonProperty("")]
        public List<string> Empty { get; set; }

        [JsonProperty("model.Password")]
        public List<string> ModelPassword {get; set;}

        [JsonProperty("model.ConfirmPassword")]
        public List<string> ModelConfirmPassword { get; set; }
    }
}