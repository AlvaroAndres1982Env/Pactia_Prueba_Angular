using FBUsuarios.Modelo;
using Microsoft.EntityFrameworkCore;

namespace FBUsuarios
{
    public class AplicationDbContext :DbContext
    {
        DbSet<Usuario> pactia { get; set;}

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options) 
        { 
        
        }

    }
}
