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
    public class HangerController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public HangerController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetHangersList()
        {
            var hangersList = await _context.Hangers.OrderBy(r => r.Id).Select(res => _mapper.Map<HangersViewModel>(res)).ToListAsync();
            if (hangersList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(hangersList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("hanger/{id}")]
        public async Task<IActionResult> GetHangersById(int id)
        {
            try
            {
                var hangerItem = await _context.Hangers.SingleOrDefaultAsync(x => x.Id == id);
                if (hangerItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<HangersViewModel>(hangerItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("hangeredit/{id}")]
        public async Task<IActionResult> EditHangersById(int id, [FromBody] EditHangerViewModel model)
        {
            try
            {
                var hangerItem = await _context.Hangers.SingleOrDefaultAsync(x => x.Id == id);
                if (hangerItem != null)
                {
                    hangerItem.Price = model.Price;
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
        [Route("hangereditbypercent/{koef}")]
        public async Task<IActionResult> EditHangerByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Hangers.ToListAsync();
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
