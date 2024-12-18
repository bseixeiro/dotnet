using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models.Event;
using mvc.Models.Student;
using mvc.Models.Teacher;

namespace mvc.Data;

public class ApplicationDbContext : IdentityDbContext<Account>  
{
    public DbSet<Student> Students { get; set; }    
    public DbSet<Teacher> Teachers { get; set; }     
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)       
    {            
        base.OnModelCreating(builder);            
        builder.Entity<Account>(entity => { entity.ToTable("Accounts"); });            
        builder.Entity<Student>(entity => { entity.ToTable("Students"); });          
        builder.Entity<Teacher>(entity => { entity.ToTable("Teachers"); });
        builder.Entity<Teacher>(entity => { entity.ToTable("Teachers"); });
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
}