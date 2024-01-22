using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class ProductEntity
    {
        public int idProduct { get; set; }
        public int Partia { get; set; }
        public string Name { get; set; }
        public int idСategory { get; set; }
        public int idRazreshenie { get; set; }        
        public double Price { get; set; }
        public DateTime? Date_delete { get; set; }
        [JsonIgnore]
        public CategoriaEntity Categoria { get; set; }
        public RazreshenieEntity Razreshenie { get; set; }
    }
}
