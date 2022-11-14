namespace DesafioAPI.Model
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }
        public List<Venta> ProductosVendidos { get; set; }

    }
}
