using System;
using System.Collections.Generic;

namespace Super.Digital.Domain.Model
{
    public class AccountModel : BaseModel
    {
        public Guid AccountId { get; set; }
        public string Number { get; set; }

        public IEnumerable<AccountEntryModel> Entries { get; set; }
    }

    public class AccountEntryModel :BaseModel
    {
        public Guid AccountEntryId { get; set; }
        public  Guid AccountId { get; set; }        
        public decimal Value { get; set; }

        /* EF */
        public AccountModel Account { get; set; }

    }  


    public class EntryModel : BaseModel
    {
        public string OriginAccountNumber { get; set; }
        public string DestinyAccountNumber { get; set; }
        public decimal Value { get; set; }

    }
}
