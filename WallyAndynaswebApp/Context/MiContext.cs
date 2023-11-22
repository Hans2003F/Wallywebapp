using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WallyAndynaswebApp.Models;

namespace WallyAndynaswebApp.Context
{
    public class MiContext:DbContext
    {
        public MiContext(DbContextOptions options):base(options) 
        {
            
        }
        //que modelos deben de trabajar con la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
