using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.Model
{
    public class Producto
    {

        public int Id { get; set; }
        [Required]
        public string Descripciones { get; set; }
        [Required]
        public double Costo { get; set; }
        [Required]
        public double PrecioVenta { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int IdUsuario { get; set; }

    }
}
