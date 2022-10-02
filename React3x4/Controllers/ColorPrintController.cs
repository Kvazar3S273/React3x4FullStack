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
    public class ColorPrintController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public ColorPrintController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetColorPrintsList()
        {
            var colorPrintsList = await _context.ColorPrints.OrderBy(r => r.Id).Select(res => _mapper.Map<ColorPrintViewModel>(res)).ToListAsync();
            if (colorPrintsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(colorPrintsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("colorprint/{id}")]
        public async Task<IActionResult> GetColorPrintsById(int id)
        {
            try
            {
                var colorPrintItem = await _context.ColorPrints.SingleOrDefaultAsync(x => x.Id == id);
                if (colorPrintItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<ColorPrintViewModel>(colorPrintItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("colorprintedit/{id}")]
        public async Task<IActionResult> EditColorPrintsById(int id, [FromBody] EditColorPrintViewModel model)
        {
            try
            {
                var colorPrintItem = await _context.ColorPrints.SingleOrDefaultAsync(x => x.Id == id);
                if (colorPrintItem != null)
                {
                    colorPrintItem.Price25 = model.Price25;
                    colorPrintItem.Price50 = model.Price50;
                    colorPrintItem.Price100 = model.Price100;
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
