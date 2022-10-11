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
    public class LaminateController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public LaminateController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetLaminatesList()
        {
            var laminatesList = await _context.Laminates.OrderBy(r => r.Id).Select(res => _mapper.Map<LaminatesViewModel>(res)).ToListAsync();
            if (laminatesList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(laminatesList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("laminate/{id}")]
        public async Task<IActionResult> GetLaminatesById(int id)
        {
            try
            {
                var laminateItem = await _context.Laminates.SingleOrDefaultAsync(x => x.Id == id);
                if (laminateItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<LaminatesViewModel>(laminateItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("laminateedit/{id}")]
        public async Task<IActionResult> EditLaminatesById(int id, [FromBody] EditLaminateViewModel model)
        {
            try
            {
                var laminateItem = await _context.Laminates.SingleOrDefaultAsync(x => x.Id == id);
                if (laminateItem != null)
                {
                    laminateItem.Price = model.Price;
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
