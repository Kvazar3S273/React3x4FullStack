using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React3x4.Constants;
using React3x4.Mapper.MapperModels;
using React3x4.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DuplicateController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public DuplicateController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetDuplicateList()
        {
            var duplicatesList = await _context.PhotoDuplicates.OrderBy(r => r.Id)
                .Select(res => _mapper.Map<DuplicatesViewModel>(res)).ToListAsync();
            if (duplicatesList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(duplicatesList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("duplicate/{id}")]
        public async Task<IActionResult> GetDuplicateById(int id)
        {
            try
            {
                var duplicateItem = await _context.PhotoDuplicates.SingleOrDefaultAsync(x => x.Id == id);
                if (duplicateItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<DuplicatesViewModel>(duplicateItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("duplicateedit/{id}")]
        public async Task<IActionResult> EditDuplicatesById(int id, [FromBody] EditDuplicateViewModel model)
        {
            try
            {
                var duplicateItem = await _context.PhotoDuplicates.SingleOrDefaultAsync(x => x.Id == id);
                if (duplicateItem != null)
                {
                    duplicateItem.PriceFirst = model.PriceFirst;
                    duplicateItem.PriceEachOther = model.PriceEachOther;
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
