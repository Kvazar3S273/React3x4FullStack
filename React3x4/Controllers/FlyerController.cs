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
    public class FlyerController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public FlyerController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetFlyersList()
        {
            var flyersList = await _context.Flyers.OrderBy(r => r.Id).Select(res => _mapper.Map<FlyersViewModel>(res)).ToListAsync();
            if (flyersList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(flyersList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("flyer/{id}")]
        public async Task<IActionResult> GetFlyersById(int id)
        {
            try
            {
                var flyerItem = await _context.Flyers.SingleOrDefaultAsync(x => x.Id == id);
                if (flyerItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<FlyersViewModel>(flyerItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("flyeredit/{id}")]
        public async Task<IActionResult> EditFlyersById(int id, [FromBody] EditFlyerViewModel model)
        {
            try
            {
                var flyerItem = await _context.Flyers.SingleOrDefaultAsync(x => x.Id == id);
                if (flyerItem != null)
                {
                    flyerItem.Price = model.Price;
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
        [Route("flyereditbypercent/{koef}")]
        public async Task<IActionResult> EditFlyerByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Flyers.ToListAsync();
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
