using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
     

    public class reg_eu_SectorCreateDTO
    {
        [Required]
        public string SubareaText { get; set; }
        [Required]
        public string SectorId { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
    }

    public class reg_eu_SectorUpdateDTO
    {
        [Required]
        public int reg_eu_SectorId { get; set; }
        [Required]
        public string SubareaText { get; set; }
        [Required]
        public string SectorId { get; set; }
        
        public DateTime UploadDate { get; set; }
    }

    public class reg_eu_SectorDeleteDTO
    {
        [Required]
        public int reg_eu_SectorId { get; set; }
     
        public string SubareaText { get; set; }
        
        public string SectorId { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
