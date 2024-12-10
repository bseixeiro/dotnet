using Microsoft.EntityFrameworkCore;

namespace mvc.Data;

public class ApplicationDbContext : DBContext {

    public ApplicationDbContext(DbContextOptions<ApplicatitonDbContext> options) : base(options){
    }

    public DbSet<Teacher> Teachers {get; set;}
    public DbSet<Student> Students {get; set;}
}