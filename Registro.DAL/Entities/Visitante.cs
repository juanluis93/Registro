using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Registro.DAL.Entities
{
    [Table("Visitantes",Schema = "dbo")]
    public class Visitante
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Apellido")]
        public string Apellido { get; set ; }
        [Column("Carrera")]
        public string Carrera { get; set; }
        [Column("Correo")]
        public string Correo { get; set; }
        [Column("HoraEntrada")]
        public DateTime HoraEntrada { get; set; }
        [Column("HoraSalida")]
        public DateTime HoraSalida { get; set; }
        [Column("MotivoVisita")]
        public string MotivoVisita { get; set; }
        [Column("Aula")]
        public string Aula { get; set; }
        [Column("Edificio")]
        public string Edificio { get; set; }
    }
}
