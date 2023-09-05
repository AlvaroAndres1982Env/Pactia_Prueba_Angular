
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace FBUsuarios.Controllers
{
    using FBUsuarios.conex;
    using Microsoft.AspNetCore.Mvc;
    using Transversal;

    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : ControllerBase
    {
        AccesoBd.Conex Cone = Conexion.conexion();

        // GET: api/<Usuario>
        [HttpGet]
        public List<usuario> Get()
        {
            Negocio.Usuario Obj = new Negocio.Usuario(Cone);
            return Obj.listausuarios();
        }

        // POST api/<Usuario>
        [HttpPost]
        public usuario Post(usuario value)
        {
            Negocio.Usuario Obj = new Negocio.Usuario(Cone);
            Obj.Guardar(value);
            return value;
        }

        // PUT api/<Usuario>/5
        [HttpPut("{id}")]
        public respuesta Put(int id, [FromBody] usuario value)
        {
            respuesta respuesta = new respuesta();
            Negocio.Usuario Obj = new Negocio.Usuario(Cone);
            value.Id = id;
            Obj.Actualizar(value);
            respuesta.Message = "La usuario fue actualizada con éxito.";
            return respuesta;
        }

        // DELETE api/<Usuario>/5
        [HttpDelete("{id}")]
        public respuesta Delete(int id)
        {
            respuesta respuesta = new respuesta();
            Negocio.Usuario Obj = new Negocio.Usuario(Cone);
            Obj.Eliminar(id);
            respuesta.Message = "La usuario fue Eliminada con éxito.";
            return respuesta;
        }
    }
}