using AutoMapper;
using DataLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React3x4.Constants;
using React3x4.Mapper.MapperModels;
using React3x4.Models.PoligraphEditVM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VisitcardController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public VisitcardController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetVisitcardsList()
        {
            var visitcardsList = await _context.Visitcards.OrderBy(r => r.Id).Select(res => _mapper.Map<VisitcardsViewModel>(res)).ToListAsync();
            if (visitcardsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(visitcardsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("visitcard/{id}")]
        public async Task<IActionResult> GetVisitcardsById(int id)
        {
            try
            {
                var visitcardItem = await _context.Visitcards.SingleOrDefaultAsync(x => x.Id == id);
                if (visitcardItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<VisitcardsViewModel>(visitcardItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("visitcardedit/{id}")]
        public async Task<IActionResult> EditVivitcardsById(int id, [FromBody] EditVisitcardViewModel model)
        {
            try
            {
                var visitcardItem = await _context.Visitcards.SingleOrDefaultAsync(x => x.Id == id);
                if (visitcardItem != null)
                {
                    visitcardItem.Price = model.Price;
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
