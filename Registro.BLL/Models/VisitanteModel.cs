using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Models
{
    public class VisitanteModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
        public string Correo { get; set; }
        public string Edificio { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public string MotivoVisita { get; set; }
        public string Aula { get; set; }
        public object Edad { get; set; }
    }
}
