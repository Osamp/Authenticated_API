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
public class ProductController : ControllerBase
{
    
    private readonly ILogger<ShoppingCartController> _logger;
    private readonly AppSecurityContext _dbSec;
    private readonly AppDataContext _dbData;


    public ProductController(ILogger<ShoppingCartController> logger
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
        var cart =await _dbData.Products.ToListAsync();
        return cart;
    }

     // POST: api/ShoppingCart/{id}
    [HttpPost("remove/{id}")]
    public async Task<IActionResult> RemoveItem(int id)
    {
        var item = await  _dbData.Products.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

         _dbData.Products.Remove(item);
        await _dbData.SaveChangesAsync();

        return NoContent();
    }
          

 [HttpPost("{id}/add")]
    public async Task<IActionResult> AddItem(int id)
    {
        var product = await _dbData.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var userEmail = User.Identity?.Name ?? String.Empty;

        var cart = await _dbData.ShoppingCarts
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


