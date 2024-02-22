using Microsoft.EntityFrameworkCore;

namespace ShoppingApi.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options)
       : base(options)
       {}
}