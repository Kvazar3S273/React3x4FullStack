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
    public class BinerController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public BinerController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBanersList()
        {
            var banersList = await _context.Baners.OrderBy(r => r.Id).Select(res => _mapper.Map<BanersViewModel>(res)).ToListAsync();
            if (banersList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(banersList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("biner/{id}")]
        public async Task<IActionResult> GetBanersById(int id)
        {
            try
            {
                var banerItem = await _context.Baners.SingleOrDefaultAsync(x => x.Id == id);
                if (banerItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<BanersViewModel>(banerItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("bineredit/{id}")]
        public async Task<IActionResult> EditBanersById(int id, [FromBody] EditBanerViewModel model)
        {
            try
            {
                var banerItem = await _context.Baners.SingleOrDefaultAsync(x => x.Id == id);
                if (banerItem != null)
                {
                    banerItem.Price = model.Price;
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
        [Route("binereditbypercent/{koef}")]
        public async Task<IActionResult> EditBanerByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Baners.ToListAsync();
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
