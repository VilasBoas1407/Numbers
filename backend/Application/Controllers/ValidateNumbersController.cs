using api.Domain;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace backend.Controllers
{
    [Route("api/number")]
    [ApiController]
    public class ValidateNumbersController : ControllerBase
    {
        [Route("{number}")]
        public object GetNumberInfo([FromRoute] int number)
        {

            try
            {
                NumberInfo numberInfo = ValidateNumber.Execute(number);

                return StatusCode((int)HttpStatusCode.OK, numberInfo);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
