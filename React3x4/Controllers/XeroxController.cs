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
    public class XeroxController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public XeroxController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetXeroxesList()
        {
            var xeroxesList = await _context.Xeroxes.OrderBy(r => r.Id).Select(res => _mapper.Map<XeroxViewModel>(res)).ToListAsync();
            if (xeroxesList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(xeroxesList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("xerox/{id}")]
        public async Task<IActionResult> GetXeroxesById(int id)
        {
            try
            {
                var xeroxItem = await _context.Xeroxes.SingleOrDefaultAsync(x => x.Id == id);
                if (xeroxItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<XeroxViewModel>(xeroxItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("xeroxedit/{id}")]
        public async Task<IActionResult> EditXeroxesById(int id, [FromBody] EditXeroxViewModel model)
        {
            try
            {
                var xeroxItem = await _context.Xeroxes.SingleOrDefaultAsync(x => x.Id == id);
                if (xeroxItem != null)
                {
                    xeroxItem.Price = model.Price;
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
