using Super.Digital.Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Super.Digital.Domain.Model
{
    public class BaseModel
    {
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        [NotMapped]
        public OperationType Operation { get; set; }
    }
}
