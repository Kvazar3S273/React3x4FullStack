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
    public class ScanningController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public ScanningController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetScanningsList()
        {
            var scanningsList = await _context.Scannings.OrderBy(r => r.Id).Select(res => _mapper.Map<ScanningsViewModel>(res)).ToListAsync();
            if (scanningsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(scanningsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("scanning/{id}")]
        public async Task<IActionResult> GetScanningsById(int id)
        {
            try
            {
                var scanningItem = await _context.Scannings.SingleOrDefaultAsync(x => x.Id == id);
                if (scanningItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<ScanningsViewModel>(scanningItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("scanningedit/{id}")]
        public async Task<IActionResult> EditScanningsById(int id, [FromBody] EditScanningViewModel model)
        {
            try
            {
                var scanningItem = await _context.Scannings.SingleOrDefaultAsync(x => x.Id == id);
                if (scanningItem != null)
                {
                    scanningItem.Price = model.Price;
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
