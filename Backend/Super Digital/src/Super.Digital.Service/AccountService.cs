using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super.Digital.Data;
using Super.Digital.Data.Repository;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Domain.Types;
using Super.Digital.Domain.Validations;
using Super.Digital.Infrastructure.Notifiers;

namespace Super.Digital.Service
{
    public class AccountService : EntityRepository<AccountModel>, IAccountService
    {
        private readonly INotifier _notifier;
        private readonly BaseService _baseService;
        public AccountService(
            INotifier notifier,
            SuperDigitalDbContext db) : base(db)
        {
            _notifier = notifier;
            _baseService = new BaseService(_notifier);
        }

        private void Validation(AccountModel accountModel)
        {
            if (!_baseService.ExecuteValidation(new AccountValidation(), accountModel)) return;
           
            if (Query(src => src.Number == accountModel.Number && src.AccountId != accountModel.AccountId).Result.Any())
            {
                _notifier.SetNotification(new Notification("Já existe uma conta cadastrada com esse número."));
                return;
            }
        }

        public async Task Save(AccountModel accountModel)
        {
            Validation(accountModel);
            if (_notifier.HasNotification())
            {
                return;
            }
            if (accountModel.Operation == OperationType.Insert)
            {
                await base.Insert(accountModel);
            }
            else
            {
                await base.Update(accountModel);
            }
        }

        public async Task Delete(AccountModel accountModel)
        {
            await base.Remove(accountModel);
        }

        public async Task<IEnumerable<AccountModel>> Select()
        {
            return await base.List();
        }
    }
}
