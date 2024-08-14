using Microsoft.EntityFrameworkCore;

namespace OrderSubscriber.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CheckOutOrder> CheckOutOrders { get; set; }
}
