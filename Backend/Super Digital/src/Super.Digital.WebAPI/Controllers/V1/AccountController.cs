using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Super.Digital.Domain.Interface;
using Super.Digital.Infrastructure.Notifiers;
using Super.Digital.WebAPI.ViewModel;
using Super.Digital.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Super.Digital.WebAPI.Controllers.V1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : MainController
    {
        private readonly IAccountService _accountService;
        public AccountController(
            IAccountService accountService,
            INotifier notifier, 
            IMapper mapper) : base(notifier, mapper)
        {
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<AccountViewModel>> Create(AccountViewModel createAccount)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
                var createAccountModel = _mapper.Map<AccountModel>(createAccount);
                await _accountService.Save(createAccountModel);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(createAccount);
        }

        [HttpGet("list")]
        public async Task<IEnumerable<AccountViewModel>> List()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<AccountViewModel>>(await _accountService.Select());
                return result;
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return (IEnumerable<AccountViewModel>)BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{accountId}")]
        public async Task<IActionResult> Delete(Guid accountId)
        {
            try
            {
                var account = _accountService.Select().Result?.Where(src => src.AccountId == accountId).FirstOrDefault();
                if (account == null) return NotFound();
                await _accountService.Delete(account);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);

            }
            return CustomResponse(accountId);
        }
    }
}
