using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashFlow.Api.Repository;
using CashFlow.Repository.Models.UBudget;

namespace CashFlow.Api.Controllers
{
    [Route("api/user/budget")]
    [ApiController]
    public class UserBudgetController : ControllerBase
    {
        private readonly CashFlowDbContext _context;

        public UserBudgetController(CashFlowDbContext context)
        {
            _context = context;
        }

        // TODO Complete
        // // GET: api/Accounts
        // [HttpPut("start")]
        // public async Task<IActionResult> StartBudget()
        // {
        //     var buckets = await _context.Buckets
        //         .Select(x => new UserBucket() 
        //         {
        //             BucketId = x.BucketId,
        //             Percentage = x.Percentage,
        //             UserId = this.User.GetUserId(),
        //         });
        // }
    }
}