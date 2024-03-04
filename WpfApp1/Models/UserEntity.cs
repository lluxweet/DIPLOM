using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class UserEntity
    {
        public int idUser { get; set; }
        public int idRole { get; set; }
        public string Familia { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }           
        public RoleEntity Role { get; set; }

        [JsonIgnore]
        public Visibility delet => idUser == 1 ? Visibility.Collapsed : Visibility.Visible;
    }
}
