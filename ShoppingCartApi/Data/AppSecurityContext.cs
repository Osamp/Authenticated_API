using Microsoft.EntityFrameworkCore;

namespace ShoppingApi.Data;

public class AppSecurityContext : DbContext<ShoppingUser>
{
    public AppSecurityContext(DbContextOptions<AppSecurityContext> options)
       : base(options)
       {}
}