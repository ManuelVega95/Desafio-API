using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class ADO_IniciarSesion
    {
        //INICIAR SESION
        public static Usuario IniciarSesion(string NombreUsuario, string Contraseña, SqlConnection conn)
        {
            Usuario usuario = null;
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();  

            cmd.CommandText = String.Format("SELECT * FROM Usuario where NombreUsuario = '{0}' AND Contraseña = '{1}'", NombreUsuario, Contraseña);
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario usuario2 = new Usuario();
                    usuario2.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario2.Nombre = reader.GetValue(1).ToString();
                    usuario2.Apellido = reader.GetValue(2).ToString();
                    usuario2.NombreUsuario = reader.GetValue(3).ToString();
                    usuario2.Contraseña = reader.GetValue(4).ToString();
                    usuario2.Mail = reader.GetValue(5).ToString();
                    usuario = usuario2;
                }
            }
            reader.Close();
            conn.Close();
            return usuario;
        }
    }
}