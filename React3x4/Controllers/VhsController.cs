using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using React3x4.Constants;
using React3x4.Mapper.MapperModels.CompVM;
using React3x4.Models.CompEditVM;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VhsController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public VhsController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetVhsesList()
        {
            var vhsesList = await _context.Vhses.OrderBy(r => r.Id).Select(res => _mapper.Map<VhsesViewModel>(res)).ToListAsync();
            if (vhsesList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(vhsesList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("vhs/{id}")]
        public async Task<IActionResult> GetVhsesById(int id)
        {
            try
            {
                var vhsItem = await _context.Vhses.SingleOrDefaultAsync(x => x.Id == id);
                if (vhsItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<VhsesViewModel>(vhsItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("vhsedit/{id}")]
        public async Task<IActionResult> EditVhsesById(int id, [FromBody] EditVhsViewModel model)
        {
            try
            {
                var vhsItem = await _context.Vhses.SingleOrDefaultAsync(x => x.Id == id);
                if (vhsItem != null)
                {
                    vhsItem.Price = model.Price;
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
