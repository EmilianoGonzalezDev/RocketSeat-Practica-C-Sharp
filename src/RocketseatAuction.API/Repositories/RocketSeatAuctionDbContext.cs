using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketSeatAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\Emiliano G\Downloads\leilaoDbNLW.db");
    }
}
