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
    public class EmailController : ControllerBase
    {
        private readonly AppEFContext _context;
        private readonly IMapper _mapper;

        public EmailController(AppEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetEmailsList()
        {
            var emailsList = await _context.Emails.OrderBy(r => r.Id).Select(res => _mapper.Map<EmailsViewModel>(res)).ToListAsync();
            if (emailsList == null)
            {
                return BadRequest(new { message = "There is no data for display!" });
            }
            return Ok(emailsList);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("email/{id}")]
        public async Task<IActionResult> GetEmailsById(int id)
        {
            try
            {
                var emailItem = await _context.Emails.SingleOrDefaultAsync(x => x.Id == id);
                if (emailItem == null)
                {
                    return NotFound(new { message = "There is no data for display!" });
                }
                return Ok(_mapper.Map<EmailsViewModel>(emailItem));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [Route("emailedit/{id}")]
        public async Task<IActionResult> EditEmailsById(int id, [FromBody] EditEmailViewModel model)
        {
            try
            {
                var emailItem = await _context.Emails.SingleOrDefaultAsync(x => x.Id == id);
                if (emailItem != null)
                {
                    emailItem.Price = model.Price;
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
