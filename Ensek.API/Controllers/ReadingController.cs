using System;
using System.Linq;
using System.Threading.Tasks;
using Ensek.BLL.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IMeterReadingService _meterReadingService;
        private readonly IAccountService _accountService;

        public ReadingController(IAccountService accountService, IMeterReadingService meterReadingService)
        {
            this._meterReadingService = meterReadingService;
            this._accountService = accountService;
        }

        [HttpPost("/meter-reading-uploads")]
        public async Task<IActionResult> UploadReadings(string fileName)
        {
            try
            {
                var summary = await _meterReadingService.UploadReadings(fileName);

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }

        }
        


    }
}