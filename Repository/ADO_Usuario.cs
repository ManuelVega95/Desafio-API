using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class ADO_Usuario
    {
        //TRAER USUARIOS - CLASE 14
        public static List<Usuario> DevolverUsuarios()
        {
            var listaUsuario = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contraseña = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();

                    listaUsuario.Add(usuario);
                }
                reader.Close();
                conn.Close();
            }
            return listaUsuario;
        }

        //MODIFICAR USUARIOS - DESAFÍO ENTREGABLE
        public static void ModificarUsuario(Usuario usu)
        {
            var listaUsuario = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("UPDATE Usuario SET Nombre = '{1}', Apellido = '{2}', NombreUsuario = '{3}', Contraseña = '{4}', Mail = '{5}' WHERE Id = {0}", usu.Id, usu.Nombre, usu.Apellido, usu.NombreUsuario, usu.Contraseña, usu.Mail);

                var paramId = new SqlParameter();
                paramId.ParameterName = "Id";
                paramId.SqlDbType = SqlDbType.BigInt;
                paramId.Value = usu.Id;

                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "Nombre";
                paramNombre.SqlDbType = SqlDbType.VarChar;
                paramNombre.Value = usu.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "Apellido";
                paramApellido.SqlDbType = SqlDbType.VarChar;
                paramApellido.Value = usu.Apellido;

                var paramNombreUsuario = new SqlParameter();
                paramNombreUsuario.ParameterName = "NombreUsuario";
                paramNombreUsuario.SqlDbType = SqlDbType.VarChar;
                paramNombreUsuario.Value = usu.NombreUsuario;

                var paramContraseña = new SqlParameter();
                paramContraseña.ParameterName = "Contraseña";
                paramContraseña.SqlDbType = SqlDbType.VarChar;
                paramContraseña.Value = usu.Contraseña;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "Mail";
                paramMail.SqlDbType = SqlDbType.VarChar;
                paramMail.Value = usu.Mail;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNombreUsuario);
                cmd.Parameters.Add(paramContraseña);
                cmd.Parameters.Add(paramMail);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();

                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetValue(1).ToString();
                        usuario.Apellido = reader.GetValue(2).ToString();
                        usuario.NombreUsuario = reader.GetValue(3).ToString();
                        usuario.Contraseña = reader.GetValue(4).ToString();
                        usuario.Mail = reader.GetValue(5).ToString();

                        listaUsuario.Add(usuario);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
        }
    }
}