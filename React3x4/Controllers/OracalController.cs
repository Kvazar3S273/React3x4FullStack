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
    public class OracalController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public OracalController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetOracalsList()
        {
            var oracalsList = await _context.Oracals.OrderBy(r => r.Id).Select(res => _mapper.Map<OracalsViewModel>(res)).ToListAsync();
            if (oracalsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(oracalsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("oracal/{id}")]
        public async Task<IActionResult> GetOracalsById(int id)
        {
            try
            {
                var oracalItem = await _context.Oracals.SingleOrDefaultAsync(x => x.Id == id);
                if (oracalItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<OracalsViewModel>(oracalItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("oracaledit/{id}")]
        public async Task<IActionResult> EditOracalsById(int id, [FromBody] EditOracalViewModel model)
        {
            try
            {
                var oracalItem = await _context.Oracals.SingleOrDefaultAsync(x => x.Id == id);
                if (oracalItem != null)
                {
                    oracalItem.Price = model.Price;
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
        [Route("oracaleditbypercent/{koef}")]
        public async Task<IActionResult> EditOracalByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Oracals.ToListAsync();
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
