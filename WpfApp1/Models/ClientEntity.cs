using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class ClientEntity
    {
        public int idClient { get; set; }
        public string Familia { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public int idOrganizacia { get; set; }
        public int idPredprinimatel { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }

        [JsonIgnore]
        public OrganizaciaEntity Organizacia { get; set; }

        [JsonIgnore]
        public PredprinimatelEntity Predprinimatel { get; set; }

        public string FIO => Familia + " " + Name + " " + Otchestvo + "" + ", " + Passport + " ";
    }
}
