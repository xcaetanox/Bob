using Bobson.Core.DTO;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class RelPerformanceDTO
    {

        public string nome { get; set; }
        public DateTime data { get; set; }
        public string tipo { get; set; }
        public string obs { get; set; }
        public int totalLiga { get; set; }
        public int totalVisita { get; set; }



        public RelPerformanceDTO()
        {

        }
    }

   
}

