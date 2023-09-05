namespace Negocio
{
    using System.Data;
    using Transversal;
    public class Usuario
    {
        AccesoBd.Conex objConex;
        public Usuario(AccesoBd.Conex strcadena)
        {
            objConex = strcadena;
        }
        public List<usuario> listausuarios()
        {
            try
            {
                object[] par = { "lista", 0, "", "", "" };
                DataTable dt = new DataTable();
                dt = objConex.getDataTable("usp_Usuarios", par);

                List<Transversal.usuario> valor = new List<Transversal.usuario>();

                foreach (DataRow item in dt.Rows)
                {
                    valor.Add(new usuario
                    {
                        Id = int.Parse(item["Id"].ToString()),
                        nombre = item["Nombre"].ToString(),
                        apellido = item["Apellido"].ToString(),
                        documento = item["Cedula"].ToString()
                    });
                }
                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Guardar(usuario U)
        {
            try
            {
                object[] par = { "Guardar", 1, U.documento, U.nombre, U.apellido };
                return objConex.EjecutarSentencia("usp_Usuarios", par);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Actualizar(usuario U)
        {
            try
            {
                object[] par = { "Actualizar", U.Id, U.documento, U.nombre, U.apellido };
                return objConex.EjecutarSentencia("usp_Usuarios", par);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Eliminar(int U)
        {
            try
            {
                object[] par = { "Eliminar", U, "", "", "" };
                return objConex.EjecutarSentencia("usp_Usuarios", par);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
