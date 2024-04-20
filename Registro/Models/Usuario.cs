namespace Registro.Web.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Admin { get; set; }
    }
}
