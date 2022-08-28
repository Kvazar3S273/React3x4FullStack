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
    public class PhotopictureController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public PhotopictureController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPhotopictureList()
        {
            var photopictureList = await _context.PhotoPictures.OrderBy(r => r.Id)
                .Select(res => _mapper.Map<PhotopicturesViewModel>(res)).ToListAsync();
            if (photopictureList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(photopictureList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("photopicture/{id}")]
        public async Task<IActionResult> GetPhotopictureById(int id)
        {
            try
            {
                var photopictureItem = await _context.PhotoPictures.SingleOrDefaultAsync(x => x.Id == id);
                if (photopictureItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<PhotopicturesViewModel>(photopictureItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("photopictureedit/{id}")]
        public async Task<IActionResult> EditPhotopicturesById(int id, [FromBody] EditPhotopictureViewModel model)
        {
            try
            {
                var photopictureItem = await _context.PhotoPictures.SingleOrDefaultAsync(x => x.Id == id);
                if (photopictureItem != null)
                {
                    photopictureItem.Price = model.Price;
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
