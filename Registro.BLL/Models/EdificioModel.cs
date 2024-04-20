using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Models
{
    public class EdificioModel
    {
        public int ID { get; set; }
        public string Direccion { get; set; }
        public string? Nombre { get; internal set; }
    }
}
