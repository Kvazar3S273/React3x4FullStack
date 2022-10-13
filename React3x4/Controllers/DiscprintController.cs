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
    public class DiscprintController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public DiscprintController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetDiscprintsList()
        {
            var discprintsList = await _context.Discprints.OrderBy(r => r.Id).Select(res => _mapper.Map<DiscprintsViewModel>(res)).ToListAsync();
            if (discprintsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(discprintsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("discprint/{id}")]
        public async Task<IActionResult> GetDiscprintsById(int id)
        {
            try
            {
                var discprintItem = await _context.Discprints.SingleOrDefaultAsync(x => x.Id == id);
                if (discprintItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<DiscprintsViewModel>(discprintItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("discprintedit/{id}")]
        public async Task<IActionResult> EditDiscprintsById(int id, [FromBody] EditDiscprintViewModel model)
        {
            try
            {
                var discprintItem = await _context.Discprints.SingleOrDefaultAsync(x => x.Id == id);
                if (discprintItem != null)
                {
                    discprintItem.Price = model.Price;
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
