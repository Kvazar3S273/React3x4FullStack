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
    public class BirkaController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public BirkaController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBirkasList()
        {
            var birkasList = await _context.Birkas.OrderBy(r => r.Id).Select(res => _mapper.Map<BirkasViewModel>(res)).ToListAsync();
            if (birkasList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(birkasList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("birka/{id}")]
        public async Task<IActionResult> GetBirkasById(int id)
        {
            try
            {
                var birkaItem = await _context.Birkas.SingleOrDefaultAsync(x => x.Id == id);
                if (birkaItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<BirkasViewModel>(birkaItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("birkaedit/{id}")]
        public async Task<IActionResult> EditBirkasById(int id, [FromBody] EditBirkaViewModel model)
        {
            try
            {
                var birkaItem = await _context.Birkas.SingleOrDefaultAsync(x => x.Id == id);
                if (birkaItem != null)
                {
                    birkaItem.Price = model.Price;
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
        [Route("birkaeditbypercent/{koef}")]
        public async Task<IActionResult> EditBirkaByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Birkas.ToListAsync();
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
