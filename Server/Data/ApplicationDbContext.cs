using Microsoft.EntityFrameworkCore;
using Server.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Transaction> transactionsTbl { get; set; }
    public DbSet<User> usersTbl { get; set; }
}