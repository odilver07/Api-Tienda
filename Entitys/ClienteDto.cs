using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class ClienteDto
    {
        public int? Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public ClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            Nombre = cliente.Nombre;
            Apellidos = cliente.Apellidos;
            Direccion = cliente.Direccion;
        }
    }
}
