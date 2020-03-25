using Super.Digital.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Super.Digital.Domain.Interface
{
    public interface IAccountingEntry
    {
        Task Save(AccountModel origin, AccountModel destiny);

        Task<IEnumerable<AccountModel>> Select(Guid AccountId);
    }
}
