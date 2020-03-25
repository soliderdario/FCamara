using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Super.Digital.Data;
using Super.Digital.Data.Repository;
using Super.Digital.Domain.Interface;
using Super.Digital.Domain.Model;
using Super.Digital.Infrastructure.Notifiers;

namespace Super.Digital.Service
{
    public class AccountEntryService : EntityRepository<AccountEntryModel>, IAccountEntryService
    {
        private readonly INotifier _notifier;
        public AccountEntryService(
            INotifier notifier,
            SuperDigitalDbContext db) : base(db)
        {
            _notifier = notifier;
        }

        private void Validation(AccountEntryModel origin, AccountEntryModel destiny)
        {
            if (origin.AccountId == destiny.AccountId)
            {
                _notifier.SetNotification(new Notification("Número das contas são identicas, favor informar uma número de conta diferente da outra."));
                return;
            } 
        }

        public async Task Save(AccountEntryModel origin, AccountEntryModel destiny)
        {
            Validation(origin, destiny);
            if (_notifier.HasNotification())
            {
                return;
            }
            try
            {
                Db.Database.BeginTransaction();
                await base.Insert(origin);
                await base.Insert(destiny);
                Db.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _notifier.SetNotification(new Notification("Não foi possível salvar esse registro:" + ex.Message));
                Db.Database.RollbackTransaction();               
            }
        }

        public override Task<List<AccountEntryModel>> List()
        {
            return DbSet.AsNoTracking()
                .Include(p => p.Account)
                .ToListAsync();               
        }

        public async Task<IEnumerable<AccountEntryModel>>Select(string accountNumber)
        {
          return await Task.Run(() =>
          {
              return List().Result.Where(src => src.Account.Number == accountNumber).ToList();
          });           
           
        }
    }
}
