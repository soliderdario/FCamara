using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Digital.Data.Repository
{
    public class EntityBase
    {
        protected readonly SuperDigitalDbContext Db;

        public EntityBase(SuperDigitalDbContext dbContext)
        {
            Db = dbContext;
        }
    }
}
