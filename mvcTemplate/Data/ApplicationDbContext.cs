using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;

public class ApplicationDbContext : DbContext {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
    }

    public DbSet<Teacher> Teachers {get; set;}
    public DbSet<Student> Students {get; set;}
}