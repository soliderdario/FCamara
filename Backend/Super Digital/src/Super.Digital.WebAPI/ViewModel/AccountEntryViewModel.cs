using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.ViewModel
{
    public class AccountViewModel : BaseViewModel
    {
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 7)]
        public string Number { get; set; }
    }

    public class AccountEntryViewModel
    {
        public Guid AccountId { get; set; }
        public decimal Value { get; set; }
        public string Number { get; set; }

    }    

    public class EntryViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 7)]
        public string OriginAccountNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 7)]
        public string DestinyAccountNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.1, Double.MaxValue)]
        public decimal Value { get; set; }
    }
}
