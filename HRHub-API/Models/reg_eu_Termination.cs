using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.Models
{
    [Table("reg_eu_Termination")]
    public partial class reg_eu_Termination
    {
        public int reg_eu_TerminationId  { get; set; }
        public string NameOfActionType { get; set; }
        public string Termination { get; set; }
        public DateTime UploadDate { get; set; }

    }
}
