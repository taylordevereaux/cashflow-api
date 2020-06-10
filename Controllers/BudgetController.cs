using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashFlow.Api.Repository;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly CashFlowDbContext _context;

        public BudgetController(CashFlowDbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet("buckets")]
        public async Task<IActionResult> GetBuckets()
        {
            return Ok(await _context.Buckets.ToListAsync());
        }
    }
}