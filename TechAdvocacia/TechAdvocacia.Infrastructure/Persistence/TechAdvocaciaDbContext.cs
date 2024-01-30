using Microsoft.EntityFrameworkCore;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure;

public class TechAdvocaciaDbContext :  DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Advogado> Advogados { get; set; }

    public TechAdvocaciaDbContext(DbContextOptions<TechAdvocaciaDbContext> options) : base(options)
    {
    }



}
