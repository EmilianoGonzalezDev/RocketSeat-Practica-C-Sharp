using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var repository = new RocketSeatAuctionDbContext();

            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exists = repository.Users.Any(user => user.Email.Equals(email));

            if (exists == false)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid");
            }
        }

        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("token is missing.");
        }

        return authentication["Bearer ".Length..]; //authentication[7..]; -> lo que devuelve todo el texto desde la posicion 7 en adelante
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
