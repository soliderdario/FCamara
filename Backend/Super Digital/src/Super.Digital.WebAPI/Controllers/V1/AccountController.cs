using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Infrastructure.Notifiers;
using Super.Digital.WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.Controllers.V1
{
    [Authorize]
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
        public async Task<ActionResult<CreateAccountViewModel>> Create(CreateAccountViewModel createAccount)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(createAccount);
        }

        //[HttpPost("save")]
        //public async Task<ActionResult<AccountViewModel>> Save(AccountingEntryViewModel  accountingEntryViewModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return CustomResponse(ModelState);
        //        }                

        //        var accountModel = _mapper.Map<AccountModel>(accountingEntryViewModel);
        //        await _accountService.Save(accountModel, accountModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        NotifyError(ex.Message);
        //    }
        //    return CustomResponse(accountingEntryViewModel);
        //}
    }
}
