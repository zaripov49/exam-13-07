using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Data;

public class DataContext(DbContextOptions<DataContext> options)
    : IdentityDbContext<IdentityUser, IdentityRole, string>(options)
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.Rentals)
            .WithOne(g => g.Car)
            .HasForeignKey(g => g.CarId);

        modelBuilder.Entity<Customer>()
            .HasMany(g => g.Rentals)
            .WithOne(sg => sg.Customer)
            .HasForeignKey(sg => sg.CustomerId);

        modelBuilder.Entity<Branch>()
            .HasMany(s => s.Rentals)
            .WithOne(sg => sg.Branch)
            .HasForeignKey(sg => sg.BranchId);
    }
}
