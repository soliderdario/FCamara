using System;
using Super.Digital.Domain.Types;

namespace Super.Digital.WebAPI.ViewModel
{
    public class BaseViewModel
    {
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public OperationType Operation { get; set; }
    }
}

    
