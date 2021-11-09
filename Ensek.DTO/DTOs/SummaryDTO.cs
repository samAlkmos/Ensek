using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensek.DTO.DTOs
{
    public class SummaryDTO
    {
        public int TotalReading { get; set; }
        public int ValidNo { get; set; }
        public int InvalidNo { get; set; }
        public int ExisitngNo { get; set; }
        public int NewReading { get; set; }
    }
}
