using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TableRow
    {
        public DateTime? Date { get; set; }
        public string? DayWeak { get; set; }
        public string? ActionType { get; set; }
        public string? EnteringType { get; set; }
        public string? CheckIn1 { get; set; }
        public string? CheckOut1 { get; set; }
        public string? CheckIn2 { get; set; }
        public string? CheckOut2 { get; set; }
        public string? CheckIn3 { get; set; }
        public string? CheckOut3 { get; set; } 
        public Decimal? Total { get; set; }

    }
}
