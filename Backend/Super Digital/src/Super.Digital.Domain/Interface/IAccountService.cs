using Super.Digital.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Super.Digital.Domain.Interface
{
    public interface IAccountService
    {
        Task Save(CreateAccountModel accountModel);
        Task Delete(CreateAccountModel accountModel);
        Task<IEnumerable<CreateAccountModel>> Select();

    }
}
