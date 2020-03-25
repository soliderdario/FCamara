using Super.Digital.Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.ViewModel
{
    public class AccountViewModel
    {
        public Guid AccountId { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public TransactionType Transaction { get; set; }
    }

    public class CreateAccountViewModel
    {
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(6, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 6)]
        public string Number { get; set; }
    }
}
