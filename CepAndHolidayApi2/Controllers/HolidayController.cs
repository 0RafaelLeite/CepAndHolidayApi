using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CepAndHoliday.Models;
using CepAndHoliday.Services;

namespace CepAndHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase, IHolidayServices
    {

        [HttpGet(Name = "isHoliday")]
        public async Task<Holiday> GetAsync(DateTime date)
        {
            var holiday = new Holiday();
            IHolidayServices.IsHoliday(date, holiday);
            
            return holiday;
        }
    }
}
