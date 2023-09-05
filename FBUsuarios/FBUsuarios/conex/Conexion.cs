namespace FBUsuarios.conex
{
    public class Conexion
    {
        public static AccesoBd.Conex conexion()
        {
            string cadenaConexion = "Data Source=DESKTOP-29IJM15\\LOCAL;Initial Catalog=pactia;Integrated Security=True";

            try
            {
                AccesoBd.Conex conexionBD = new AccesoBd.Conex(cadenaConexion);
                return conexionBD;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
