using System;
using System.Collections.Generic;
using System.Text;

namespace Ensek.DTO.DTOs
{
    public class MeterReadingDTO
    {
        public int AccountId { get; set; }
        public DateTime ReadingDate { get; set; }
        public string ReadingValue { get; set; }
    }
}
