using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Dtos
{
    public class AulaDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string EdificioId { get; set; } = string.Empty;
    }
}
