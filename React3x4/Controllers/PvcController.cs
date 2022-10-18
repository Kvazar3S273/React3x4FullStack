using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React3x4.Constants;
using React3x4.Mapper.MapperModels.PoligraphVM;
using React3x4.Models.PoligraphEditVM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PvcController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public PvcController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPvcsList()
        {
            var pvcsList = await _context.Pvcs.OrderBy(r => r.Id).Select(res => _mapper.Map<PvcsViewModel>(res)).ToListAsync();
            if (pvcsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(pvcsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("pvc/{id}")]
        public async Task<IActionResult> GetPvcsById(int id)
        {
            try
            {
                var pvcItem = await _context.Pvcs.SingleOrDefaultAsync(x => x.Id == id);
                if (pvcItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<PvcsViewModel>(pvcItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("pvcedit/{id}")]
        public async Task<IActionResult> EditPvcsById(int id, [FromBody] EditPvcViewModel model)
        {
            try
            {
                var pvcItem = await _context.Pvcs.SingleOrDefaultAsync(x => x.Id == id);
                if (pvcItem != null)
                {
                    pvcItem.Price = model.Price;
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

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("pvceditbypercent/{koef}")]
        public async Task<IActionResult> EditPvcByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Pvcs.ToListAsync();
                var koefForExpressionResult = 1 + (koef / 100);
                listPrices.ForEach(c => c.Price = Math.Ceiling(c.Price * koefForExpressionResult));
                _context.SaveChanges();
                return Ok(listPrices);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }
    }
}
