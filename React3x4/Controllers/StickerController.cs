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
    public class StickerController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public StickerController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetStickersList()
        {
            var stickersList = await _context.Stickers.OrderBy(r => r.Id).Select(res => _mapper.Map<StickersViewModel>(res)).ToListAsync();
            if (stickersList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(stickersList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("sticker/{id}")]
        public async Task<IActionResult> GetStickersById(int id)
        {
            try
            {
                var stickerItem = await _context.Stickers.SingleOrDefaultAsync(x => x.Id == id);
                if (stickerItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<StickersViewModel>(stickerItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("stickeredit/{id}")]
        public async Task<IActionResult> EditStickersById(int id, [FromBody] EditStickerViewModel model)
        {
            try
            {
                var stickerItem = await _context.Stickers.SingleOrDefaultAsync(x => x.Id == id);
                if (stickerItem != null)
                {
                    stickerItem.Price = model.Price;
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
        [Route("stickereditbypercent/{koef}")]
        public async Task<IActionResult> EditStickerByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Stickers.ToListAsync();
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
