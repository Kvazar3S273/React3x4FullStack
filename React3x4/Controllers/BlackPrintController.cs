using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React3x4.Constants;
using React3x4.Mapper.MapperModels.CompVM;
using React3x4.Models.CompEditVM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlackPrintController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public BlackPrintController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBlackPrintsList()
        {
            var blackPrintsList = await _context.BlackPrints.OrderBy(r => r.Id).Select(res => _mapper.Map<BlackPrintViewModel>(res)).ToListAsync();
            if (blackPrintsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(blackPrintsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("blackprint/{id}")]
        public async Task<IActionResult> GetBlackPrintsById(int id)
        {
            try
            {
                var blackPrintItem = await _context.BlackPrints.SingleOrDefaultAsync(x => x.Id == id);
                if (blackPrintItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<BlackPrintViewModel>(blackPrintItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("blackprintedit/{id}")]
        public async Task<IActionResult> EditBlackPrintsById(int id, [FromBody] EditBlackPrintViewModel model)
        {
            try
            {
                var blackPrintItem = await _context.BlackPrints.SingleOrDefaultAsync(x => x.Id == id);
                if (blackPrintItem != null)
                {
                    blackPrintItem.PriceText = model.PriceText;
                    blackPrintItem.Price100 = model.Price100;
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
    }
}
