using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Articulo
    {
        public int? Codigo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public float Precio { get; set; }

        public byte[] Imagen { get; set; }
        public string ExtesionImagen { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
