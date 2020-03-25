using Super.Digital.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Digital.Domain.Model
{
    public class AccountModel :BaseModel
    {
        public  Guid AccountId { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public TransactionType Transaction { get; set; }
    }

    public class CreateAccountModel : BaseModel
    {
        public Guid AccountId { get; set; }      
        public string Number { get; set; }
    }
}
