using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Domain.Types;
using Super.Digital.Infrastructure.Notifiers;
using Super.Digital.WebAPI.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.Controllers.V1
{
    //[Authorize]
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
                AccountId = accountModel.AccountId,                
                Value = value,
                Operation = OperationType.Insert,
                DateCreate = new DateTime()
            };
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
                var destiny = CreateAccountInstance(entry.DestinyAccountNumber, entry.Value);               
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
    }
}
