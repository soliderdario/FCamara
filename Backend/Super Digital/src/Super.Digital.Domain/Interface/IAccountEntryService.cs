﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Super.Digital.Domain.Model;

namespace Super.Digital.Domain.Interface
{
    public interface IAccountEntryService
    {
        Task Save(AccountEntryModel origin, AccountEntryModel destiny);

        Task<IEnumerable<AccountEntryModel>> Select(string accountNumber);
    }
}
