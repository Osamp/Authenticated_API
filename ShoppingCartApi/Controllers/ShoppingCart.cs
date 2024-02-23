using ShoppingApi.Data;
using ClassLibraryProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class ShoppingCartController : ControllerBase
{

    private readonly ILogger<ShoppingCartController> _logger;
    private readonly AppSecurityContext _dbSec;
    private readonly AppDataContext _dbData;


    public ShoppingCartController(ILogger<ShoppingCartController> logger
        , AppSecurityContext dbSec
        , AppDataContext dbData)

    {
        _logger = logger;
        _dbSec = dbSec;
        _dbData = dbData;

    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get()
    {
        var userEmail = User.Identity?.Name ?? String.Empty;

        var cart = await _dbData.ShoppingCarts
        .Include(c => c.Products)
        .FirstOrDefaultAsync(c => c.User == userEmail);
        return cart.Products;
    }

    // POST: api/ShoppingCart/{id}
    [HttpPost("/{id}")]
    public async Task<string> RemoveShoppingCart(int id)
    {
        var shoppingCart = await _dbData.ShoppingCarts.FindAsync(id);
        if (shoppingCart == null)
        {
            return "NotFound";
        }

        _dbData.ShoppingCarts.Remove(shoppingCart);
        await _dbData.SaveChangesAsync();

        return "Shopping cart removed";
    }


    [HttpPost("remove/{id}")]
    public async Task<IActionResult> AddToCart(int id)
    {
        var userEmail = User.Identity?.Name ?? String.Empty;
        var product = await _dbData.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }

        var cart = await _dbData.ShoppingCarts
             .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.User == userEmail);

        if (cart == null)
        {
            cart = new ShoppingCart { User = userEmail };
            _dbData.ShoppingCarts.Add(cart);
        }

        cart.Products.Add(product);

        await _dbData.SaveChangesAsync();

        return Ok(cart);
    }
}

// [AllowAnonymous]
// [HttpPost(Name = "GetWeatherForecast")]
// public IEnumerable<string> Post()
// {
//     // var ty = this.GetType();
//     // var ca = ty.GetCustomAttributesData();
//     // var ret = ca.Select(c => c.AttributeType.Name);

//     var ty = this.GetType();
//     var met = ty.GetMethods();
//     var mList = met.SelectMany(m => m.GetCustomAttributesData());
//     var ret = mList.Select(m => m.AttributeType.Name).Where(m => m.StartsWith("Http"));

//     return ret;
// }

// [AllowAnonymous]
// [HttpOptions(Name = "GetWeatherForecast")]
// public string Options()
// {
//     // var ty = this.GetType();
//     // var ca = ty.GetCustomAttributesData();
//     // var ret = ca.Select(c => c.AttributeType.Name);

//     var ty = this.GetType();
//     var met = ty.GetMethods();
//     var mList = met.SelectMany(m => m.GetCustomAttributesData());
//     var hdr = mList.Select(m => m.AttributeType.Name).Where(m => m.StartsWith("Http")).Select(m => m.Replace("Http", String.Empty).Replace("Attribute", String.Empty).ToUpper());

//     Response.Headers.Allow = String.Join(',', hdr.ToArray());

//     return String.Empty;
// }


