using System;
using System.ComponentModel.DataAnnotations.Schema;
using Super.Digital.Domain.Types;

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
