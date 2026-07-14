using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

public class PizzaStoreContext : DbContext
{
  public PizzaStoreContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Order> Orders => Set<Order>();
  public DbSet<Pizza> Pizzas => Set<Pizza>();
  public DbSet<PizzaSpecial> Specials => Set<PizzaSpecial>();
  public DbSet<Topping> Toppings => Set<Topping>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
    modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(p => p.Toppings);
    modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();
  }
}
