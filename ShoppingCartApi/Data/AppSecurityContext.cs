// using IdentityAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ClassLibraryProject;
namespace ShoppingApi.Data;

public class AppSecurityContext :IdentityDbContext
{
    public AppSecurityContext(DbContextOptions<AppSecurityContext> options)
       : base(options)
       {}
}