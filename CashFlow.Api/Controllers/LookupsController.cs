using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashFlow.Api.Business;
using CashFlow.Api.Repository;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly LookupsService _service;

        public LookupsController(LookupsService service)
        {
            _service = service;
        }

        // GET: api/AccountTypes
        [HttpGet("AccountTypes")]
        public async Task<IEnumerable<AccountType>> GetAccountTypes()
        {
            return await _service.GetAccountTypes();
        }

        // GET: api/TransactionTypes
        [HttpGet("TransactionTypes")]
        public async Task<IEnumerable<TransactionType>> GetTransactionTypes()
        {
            return await _service.GetTransactionTypes();
        }
    }
}