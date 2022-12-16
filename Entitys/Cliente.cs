using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Cliente
    {
        public int? Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string pass { get; set; }
    }
}
