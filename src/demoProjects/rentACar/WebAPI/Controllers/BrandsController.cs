using Application.Features.Brands.Commands.CreateBrandFeature;
using Application.Features.Brands.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : BaseController
    {      
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandFeatureEntityCommand createBrandFeatureEntityCommand)
        {
            CreatedBrandFeatureEntityDto result = await Mediator.Send(createBrandFeatureEntityCommand);
            return Created("", result);
        }


    }
}
