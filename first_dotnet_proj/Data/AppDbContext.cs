using first_dotnet_proj.Models;
using Microsoft.EntityFrameworkCore;
namespace first_dotnet_proj.Data;

public class AppDbContext : DbContext {
  

    public DbSet<Team>  teams {get;set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    } 
    

}