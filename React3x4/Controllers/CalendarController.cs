using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React3x4.Constants;
using React3x4.Mapper.MapperModels.PoligraphVM;
using React3x4.Models.PoligraphEditVM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalendarController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public CalendarController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCalendarsList()
        {
            var calendarsList = await _context.Calendars.OrderBy(r => r.Id).Select(res => _mapper.Map<CalendarsViewModel>(res)).ToListAsync();
            if (calendarsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(calendarsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("calendar/{id}")]
        public async Task<IActionResult> GetCalendarsById(int id)
        {
            try
            {
                var calendarItem = await _context.Calendars.SingleOrDefaultAsync(x => x.Id == id);
                if (calendarItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<CalendarsViewModel>(calendarItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("calendaredit/{id}")]
        public async Task<IActionResult> EditCalendarsById(int id, [FromBody] EditCalendarViewModel model)
        {
            try
            {
                var calendarItem = await _context.Calendars.SingleOrDefaultAsync(x => x.Id == id);
                if (calendarItem != null)
                {
                    calendarItem.Price = model.Price;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound(new { message = "There is no data for display!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("calendareditbypercent/{koef}")]
        public async Task<IActionResult> EditCalendarByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Calendars.ToListAsync();
                var koefForExpressionResult = 1 + (koef / 100);
                listPrices.ForEach(c => c.Price = Math.Ceiling(c.Price * koefForExpressionResult));
                _context.SaveChanges();
                return Ok(listPrices);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }
    }
}
