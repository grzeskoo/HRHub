using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.DTOs
{
    public class reg_eu_TerminationDTO
    {
        public int reg_eu_TerminationId { get; set; }
        public string NameOfActionType { get; set; }
        public string Termination { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
