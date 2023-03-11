using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuityCreditCalculator.Models
{
    public class InputDayCreditData
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Сумма займа должна быть больше 0")]
        [DisplayName("Сумма займа")]
        public decimal Amount { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Срок займа должен быть больше 0")]
        [DisplayName("Срок займа (в днях)")]
        public int Time { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Ставка должна быть больше 0")]
        [DisplayName("Ставка (в % за день)")]
        public decimal Rate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Шаг платежа должен быть больше 0")]
        [DisplayName("Шаг платежа (в днях)")]
        public int Step { get; set; }
    }
}
