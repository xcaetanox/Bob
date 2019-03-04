using Bobson.Core.DTO;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class RelPerformanceTotaisDTO
    {

        public DateTime data { get; set; }
        public int totalLiga { get; set; }
        public int totalVisita { get; set; }



        public RelPerformanceTotaisDTO()
        {

        }
    }

   
}

