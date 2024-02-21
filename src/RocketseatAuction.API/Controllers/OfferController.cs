using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketSeatAuctionBaseController
{
    //[HttpPost]
    //[ProducesResponseType(typeof(Offer), StatusCodes.Status200OK)]
    //public IActionResult AddOffer(/* Deberia recibir el offer desde el front o en el body */)
    //{
    //    var offer = new Offer
    //    {
    //        CreatedOn = DateTime.Now,
    //        Id = 1, //deberia ser autoincremental
    //        ItemId = 1,
    //        Price = 100,
    //        UserId = 1 //pero todavia no existen los users
    //    };

    //    var useCase = new GetCurrentAuctionUseCase();

    //    useCase.AddOffer(offer); //por el momento el metodo es void

    //    return Ok(useCase);
    //}

    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
