using System;

namespace Bobson.Core.DTO
{
    public class HourRangeDTO
    {
        public DayOfWeek Dia { get; set; }

        public int Begin{ get; set; }

        public int End{ get; set; }

        public HourRangeDTO(int dia, int begin, int end)
        {
            this.Begin = begin;
            this.End = end;
            this.Dia = (DayOfWeek)dia;
        }

        public HourRangeDTO()
        {
        }
    }
}

