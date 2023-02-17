using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Post> Posts { get; set; }
}
