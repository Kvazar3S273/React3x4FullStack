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
    public class BinderController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public BinderController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBindersList()
        {
            var bindersList = await _context.Binders.OrderBy(r => r.Id).Select(res => _mapper.Map<BindersViewModel>(res)).ToListAsync();
            if (bindersList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(bindersList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("binder/{id}")]
        public async Task<IActionResult> GetBindersById(int id)
        {
            try
            {
                var binderItem = await _context.Binders.SingleOrDefaultAsync(x => x.Id == id);
                if (binderItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<BindersViewModel>(binderItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("binderedit/{id}")]
        public async Task<IActionResult> EditBindersById(int id, [FromBody] EditBinderViewModel model)
        {
            try
            {
                var binderItem = await _context.Binders.SingleOrDefaultAsync(x => x.Id == id);
                if (binderItem != null)
                {
                    binderItem.Price = model.Price;
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
