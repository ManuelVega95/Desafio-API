using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class ADO_NombreApp
    {
        //TRAER NOMBRE
        public static NombreApp DevolverNombre()
        {
            NombreApp app = new NombreApp();
            app.Nombre = "ProyectoFinalCoder";
            return app;
        }
    }
}