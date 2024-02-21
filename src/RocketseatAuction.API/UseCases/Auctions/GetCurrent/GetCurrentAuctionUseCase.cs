using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new RocketSeatAuctionDbContext();

        var today = DateTime.Now;

        return repository
            .Auctions
            .Include(a => a.Items)
            .First();
    }
}
