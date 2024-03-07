using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly RocketSeatAuctionDbContext _dbContext;

    public OfferRepository(RocketSeatAuctionDbContext dbContext) => _dbContext = dbContext;

    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}
