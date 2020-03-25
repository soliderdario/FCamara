using Super.Digital.Data;
using Super.Digital.Data.Repository;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Infrastructure.Notifiers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Super.Digital.Service
{
    public class AccountEntryService :EntityRepository<EntryModel>, IAccountEntryService
    {
        private readonly INotifier _notifier;
        public AccountEntryService(
            INotifier notifier,
            SuperDigitalDbContext db) : base(db)
        {
            _notifier = notifier;
        }

        private void Validation(AccountModel accountModel)
        {
            // if (!_baseService.ExecuteValidation(new AccountValidation(), accountModel)) return;

            //if (Query(src => src.Number == accountModel.Number && src.AccountId != accountModel.AccountId).Result.Any())
            //{
            //    _notifier.SetNotification(new Notification("Já existe uma conta cadastrada com esse número."));
            //    return;
            //}
        }

        public async Task Save(AccountEntryModel origin, AccountEntryModel destiny)
        {
            try
            {
                Db.Database.BeginTransaction();
                

                Db.Database.CommitTransaction();

            }
            catch (Exception)
            {
                Db.Database.RollbackTransaction();               
            }
        }

        public Task<IEnumerable<AccountEntryModel>> Select(Guid AccountId)
        {
            throw new NotImplementedException();
        }
    }
}
