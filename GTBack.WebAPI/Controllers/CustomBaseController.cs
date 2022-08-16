
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GTBack.Core.DTO;
using AutoMapper;
using GTBack.Core.Services;

namespace GTBack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {




        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {

            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };

            }
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }



    }
}
