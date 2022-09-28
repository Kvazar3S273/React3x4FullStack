using DataLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppEFContext _context;
        public TestController(AppEFContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("testedit/{koef}")]
        public async Task<IActionResult> EditTestTableByKoef([FromRoute] decimal koef)
        {
            try
            {
                var listPrices = await _context.Tests.ToListAsync();
                //var koefForExpressionResult = (100 + (koef * 100))/100;
                var koefForExpressionResult = 1 + (koef / 100);
                listPrices.ForEach(c => c.AlternatePrice *= koefForExpressionResult);
                listPrices.ForEach(x => x.UserPrice = x.AlternatePrice);
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
