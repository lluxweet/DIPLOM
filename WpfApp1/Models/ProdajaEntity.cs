using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class ProdajaEntity
    {
        public int id { get; set; }
        public int idProduct { get; set; }
        public int idClient { get; set; }
        public int Colichestvo { get; set; }
        public int idStatus { get; set; }
        public int idStatusOplata { get; set; } 
        public int idTipOplata { get; set; }

        [JsonIgnore]
        public ProductEntity Product { get; set; }
        public ClientEntity Client { get; set; }
        public PredprinimatelEntity Predprinimatel { get; set; }
        public StatusEntity Status { get; set; }
        public TypeoplataEntity Typeoplata { get; set; }
        public StatusoplataEntity StatusOplata { get; set; }
        
        public int Stoimost => Convert.ToInt32(Product?.Price) * Convert.ToInt32(Colichestvo);
    }
}
