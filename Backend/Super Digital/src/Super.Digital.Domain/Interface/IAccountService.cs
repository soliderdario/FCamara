using Super.Digital.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Super.Digital.Domain.Interface
{
    public interface IAccountService
    {
        Task Save(AccountModel accountModel);
        Task Delete(AccountModel accountModel);
        Task<IEnumerable<AccountModel>> Select();

    }
}
