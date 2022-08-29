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
    public class BottleController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public BottleController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBottleList()
        {
            var bottleList = await _context.PhotoBottles.OrderBy(r => r.Id)
                .Select(res => _mapper.Map<BottlesViewModel>(res)).ToListAsync();
            if (bottleList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(bottleList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("bottle/{id}")]
        public async Task<IActionResult> GetBottleById(int id)
        {
            try
            {
                var bottleItem = await _context.PhotoBottles.SingleOrDefaultAsync(x => x.Id == id);
                if (bottleItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<BottlesViewModel>(bottleItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("bottleedit/{id}")]
        public async Task<IActionResult> EditBottlesById(int id, [FromBody] EditBottleViewModel model)
        {
            try
            {
                var bottleItem = await _context.PhotoBottles.SingleOrDefaultAsync(x => x.Id == id);
                if (bottleItem != null)
                {
                    bottleItem.Price = model.Price;
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
