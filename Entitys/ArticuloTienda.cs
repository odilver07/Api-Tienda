using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class ArticuloTienda
    {
        public int Id { get; set; }

        [Required]
        public int Articulo { get; set; }

        [Required]
        public int Tienda { get; set; }

        public DateTime Fecha { get; set; }

    }
}
