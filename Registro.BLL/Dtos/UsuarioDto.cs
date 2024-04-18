using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Dtos
{
    public class UsuarioDto
    {

        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Admin { get; set; }
    }
}
