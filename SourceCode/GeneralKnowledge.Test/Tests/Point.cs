using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// class used for mapping between json format
    /// and Object format
    // temperature  
    // pH            
    // Chloride      
    // Phosphate     
    // Nitrate       
    /// </summary>
    /// <remarks></remarks>
    public class Point
    {
        
        [JsonProperty(PropertyName = "date")]
        public DateTime? Date { get; set; }
        [JsonProperty(PropertyName = "temperature")]
        public decimal? Temperature { get;set;}
        [JsonProperty(PropertyName = "pH")]
        public int? PH { get;set;}
        [JsonProperty(PropertyName = "Chloride")]
        public int? Chloride { get;set;}
        [JsonProperty(PropertyName = "Phosphate")]
        public int? Phosphate { get;set;}
        [JsonProperty(PropertyName = "Nitrate")]
        public int? Nitrate { get; set; }
    }

   //root node  class of json file
    public class RootObject
    {
       [JsonProperty(PropertyName = "samples")]
        public List<Point> Points { get; set; }
    }

}
