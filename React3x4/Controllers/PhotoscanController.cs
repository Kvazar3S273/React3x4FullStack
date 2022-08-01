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
    public class PhotoscanController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public PhotoscanController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotoscanList()
        {
            var photoscansList = await _context.Photoscans.OrderBy(r => r.Id)
                .Select(res => _mapper.Map<PhotoscansViewModel>(res)).ToListAsync();
            if (photoscansList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(photoscansList);
        }

        [HttpGet]
        [Route("photoscan/{id}")]
        public async Task<IActionResult> GetPhotoscanById(int id)
        {
            try
            {
                var photoscanItem = await _context.Photoscans.SingleOrDefaultAsync(x => x.Id == id);
                if (photoscanItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<PhotoscansViewModel>(photoscanItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }

        [HttpPut]
        [Route("photoscanedit/{id}")]
        public async Task<IActionResult> EditPhotoscansById(int id, [FromBody] EditPhotoscanViewModel model)
        {
            try
            {
                var photoscanItem = await _context.Photoscans.SingleOrDefaultAsync(x => x.Id == id);
                if (photoscanItem != null)
                {
                    photoscanItem.Price300dpi = model.Price300dpi;
                    photoscanItem.Price600dpi = model.Price600dpi;
                    photoscanItem.Price1200dpi = model.Price1200dpi;
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
