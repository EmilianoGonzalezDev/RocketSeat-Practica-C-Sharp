using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly RocketSeatAuctionDbContext _dbContext;

    public AuctionRepository(RocketSeatAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts);
    }
}
