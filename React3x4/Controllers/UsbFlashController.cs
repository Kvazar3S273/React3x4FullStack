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
    public class UsbFlashController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public UsbFlashController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsbsList()
        {
            var usbsList = await _context.Binders.OrderBy(r => r.Id).Select(res => _mapper.Map<UsbFlashesViewModel>(res)).ToListAsync();
            if (usbsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(usbsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("usbflash/{id}")]
        public async Task<IActionResult> GetUsbsById(int id)
        {
            try
            {
                var usbItem = await _context.UsbFlashes.SingleOrDefaultAsync(x => x.Id == id);
                if (usbItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<UsbFlashesViewModel>(usbItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("usbflashedit/{id}")]
        public async Task<IActionResult> EditUsbsById(int id, [FromBody] EditUsbFlashViewModel model)
        {
            try
            {
                var usbItem = await _context.UsbFlashes.SingleOrDefaultAsync(x => x.Id == id);
                if (usbItem != null)
                {
                    usbItem.Price = model.Price;
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
