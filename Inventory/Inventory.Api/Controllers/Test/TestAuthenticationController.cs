using Inventory.AuthHelper;
using Inventory.Common;
using Inventory.Common.HttpContextUser;
using Inventory.Controllers;
using Inventory.Model;
using Inventory.Model.Models;
using Inventory.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Inventory.Api.Controllers.Test;

[Route("api/[Controller]/[Action]")]
public class TestAuthenticationController : BaseApiController
{
    public TestAuthenticationController()
    {
    }

    [HttpGet]
    public async Task<MessageModel<TokenInfoViewModel>> GetToken()
    {
        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "aa"),
                    new Claim(JwtRegisteredClaimNames.Jti, "aa"),
                    new Claim("TenantId", "112333"),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.DateToTimeStamp()),
                    new Claim(ClaimTypes.Expiration,
                        DateTime.Now.AddSeconds(60*60*24).ToString())
                };

        var token = JwtToken.BuildInnerJwtToken(claims.ToArray());
        return Success(token);
    }

    [HttpGet]
    [Authorize(Permissions.Name,AuthenticationSchemes = "Inner")]
    public async Task<IActionResult> Get()
    {
        Console.WriteLine(App.HttpContext.Request.Path);
        Console.WriteLine(App.HttpContext.RequestServices.ToString());
        Console.WriteLine(App.User?.ID);
        await Task.CompletedTask;
        return Ok("werwerwrewer");
    }
}