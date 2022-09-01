using Bank.Domain.Entities;
using Bank.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Controllers
{
    [Route("Case")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICommissionCaseRepository _commissionCaseRepository;
        public CaseController(ICommissionCaseRepository commissionCaseRepository)
        {
            this._commissionCaseRepository = commissionCaseRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCase(CommissionCase commissionCase)
        {
            await _commissionCaseRepository.CreateCase(commissionCase);
            return Ok();
        }
    }
}
