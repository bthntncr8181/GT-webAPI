
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GTBack.Core.Services;
using GTBack.Core.Results;
using System.Net;
using GTBack.Core.DTO.Response;

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
        protected IActionResult ApiResult(IResults result)
        {
            if ((int)result.StatusCode == 0)
            {
                return StatusCode((int)HttpStatusCode.OK, result);
            }

            return StatusCode((int)result.StatusCode, result);
        }


    }
}
