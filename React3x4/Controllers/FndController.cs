using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React3x4.Mapper.MapperModels;
using React3x4.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FndController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public FndController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetFndsList()
        {
            var fndsList = await _context.Fnds.OrderBy(r => r.Id).Select(res => _mapper.Map<FndsViewModel>(res)).ToListAsync();
            if (fndsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(fndsList);
        }

        [HttpGet]
        [Route("fnd/{id}")]
        public async Task<IActionResult> GetFndsById(int id)
        {
            try
            {
                var fndItem = await _context.Fnds.SingleOrDefaultAsync(x => x.Id == id);
                if (fndItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<FndsViewModel>(fndItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }

        [HttpPut]
        [Route("fndedit/{id}")]
        public async Task<IActionResult> EditFndsById(int id, [FromBody] EditFndViewModel model)
        {
            try
            {
                var fndItem = await _context.Fnds.SingleOrDefaultAsync(x => x.Id == id);
                if (fndItem != null)
                {
                    fndItem.Price = model.Price;
                    fndItem.ArchivePice = model.ArchivePice;
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
