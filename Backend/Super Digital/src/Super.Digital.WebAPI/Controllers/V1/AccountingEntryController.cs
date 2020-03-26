using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Domain.Types;
using Super.Digital.Infrastructure.Notifiers;
using Super.Digital.WebAPI.ViewModel;

namespace Super.Digital.WebAPI.Controllers.V1
{    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountingEntryController : MainController
    {
        private readonly IAccountEntryService _accountingEntryService;
        private readonly IAccountService _accountService;
        public AccountingEntryController(
            IAccountEntryService accountingEntryService,
            INotifier notifier,
            IAccountService accountService,
            IMapper mapper) : base(notifier, mapper)
        {
            _accountingEntryService = accountingEntryService;
            _accountService = accountService;
        }

        private AccountEntryModel CreateAccountInstance(string number, decimal value)
        {
            var accountModel = _accountService.Select().Result.Where(src => src.Number == number).FirstOrDefault();
            if (accountModel == null)
            {
                NotifyError("A conta de nro:" + number + "não foi encontrada!");
                return null;
            }
            return new AccountEntryModel
            {
                AccountEntryId =  System.Guid.NewGuid(),
                AccountId = accountModel.AccountId,                
                Value = value,
                Operation = OperationType.Insert,
                DateCreate = new DateTime()
            };
        }

        [HttpGet("ping")]
        public string Get()
        {
            return "Pong";
        }

        [HttpPost("create")]
        public async Task<ActionResult<EntryViewModel>> Create(EntryViewModel entry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }

                var origin = CreateAccountInstance(entry.OriginAccountNumber, entry.Value);
                var destiny = CreateAccountInstance(entry.DestinyAccountNumber, entry.Value *(-1));               
                if (!IsValid())
                {
                    return CustomResponse();
                }                
                await _accountingEntryService.Save(origin, destiny);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(entry);
        }

        [HttpGet("list/{accountNumber}")]
        public async Task<IEnumerable<AccountEntryViewModel>> List(string accountNumber)
        {
            try
            {
                var result = _mapper.Map<IEnumerable<AccountEntryViewModel>>(await _accountingEntryService.Select(accountNumber));
                return result;
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return (IEnumerable<AccountEntryViewModel>)BadRequest(ex.Message);
            }          
            
        }
    }
}
