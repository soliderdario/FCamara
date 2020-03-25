using Super.Digital.Data;
using Super.Digital.Data.Repository;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Domain.Types;
using Super.Digital.Domain.Validations;
using Super.Digital.Infrastructure.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.Service
{
    public class AccountService : EntityRepository<CreateAccountModel>, IAccountService
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

        private void Validation(CreateAccountModel accountModel)
        {
            if (!_baseService.ExecuteValidation(new AccountValidation(), accountModel)) return;
           
            if (Query(src => src.Number == accountModel.Number && src.AccountId != accountModel.AccountId).Result.Any())
            {
                _notifier.SetNotification(new Notification("Já existe uma conta cadastrada com esse número."));
                return;
            }
        }

        public async Task Save(CreateAccountModel accountModel)
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

        public async Task Delete(CreateAccountModel accountModel)
        {
            await base.Remove(accountModel);
        }

        public async Task<IEnumerable<CreateAccountModel>> Select()
        {
            return await base.List();
        }
    }
}
