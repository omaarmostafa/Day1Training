using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.Model
{
    public class Car
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Year")]
        public long Year { get; set; }

        [JsonProperty("Img")]
        public string Img { get; set; }
    }
}
