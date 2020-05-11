using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.DTOs
{
    public class reg_eu_SectorDTO
    {
        public int reg_eu_SectorId { get; set; }
        public string SubareaText { get; set; }
        public string SectorId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
