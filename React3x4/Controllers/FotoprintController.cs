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
    public class FotoprintController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public FotoprintController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetFotoprintsList()
        {
            var fotoprintsList = await _context.Fotoprints.OrderBy(r => r.Id).Select(res => _mapper.Map<FotoprintsViewModel>(res)).ToListAsync();
            if (fotoprintsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(fotoprintsList);
        }

        [HttpGet]
        [Route("fotoprint/{id}")]
        public async Task<IActionResult> GetFotoprintsById(int id)
        {
            try
            {
                var fotoprintItem = await _context.Fotoprints.SingleOrDefaultAsync(x => x.Id == id);
                if (fotoprintItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<FotoprintsViewModel>(fotoprintItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }

        [HttpPut]
        [Route("fotoprintedit/{id}")]
        public async Task<IActionResult> EditFotoprintsById(int id, [FromBody] EditFotoprintViewModel model)
        {
            try
            {
                var fotoprintItem = await _context.Fotoprints.SingleOrDefaultAsync(x => x.Id == id);
                if (fotoprintItem != null)
                {
                    fotoprintItem.Price = model.Price;
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
