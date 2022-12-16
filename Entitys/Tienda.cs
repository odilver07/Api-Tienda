using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Tienda
    {
        public int? Id { get; set; }

        [Required]
        public string Sucursal { get; set; }

        [Required]
        public string Direccion { get; set; }
    }
}
