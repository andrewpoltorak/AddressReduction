using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressReduction.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Пустое поле")]
        [Url (ErrorMessage = "Некорректный адрес")]
        public string LongAddress { get; set; }

        [Required(ErrorMessage = "Пустое поле")]
        public string ShortAddress { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int Clicked { get; set; } = 0;
    }
}
