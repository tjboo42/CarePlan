using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarePlan.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required]
        [StringLength(450)]
        public string RecordTitle { get; set; }

        [DisplayName("Patient Name")]
        [Required]
        [StringLength(450)]
        public string PatientName { get; set; }
        
        [DisplayName("User Name")]
        [Required]
        [StringLength(450)]
        public string UserName { get; set; }
        
        [DisplayName("Actual Start Date/Time")]
        [Required]
        public DateTime ActualStartDateTime { get; set; }
        
        [DisplayName("Target Date/Time")]
        [Required]
        public DateTime TargetDateTime { get; set; }

        [Required]
        [StringLength(1000)]
        public string Reason { get; set; }

        [Required]
        [StringLength(1000)]
        public string Action { get; set; }

        public bool? Completed { get; set; }

        [DisplayName("End Date/Time")]
        public DateTime EndDateTime { get; set; }

        [StringLength(1000)]
        public string Outcome { get; set; }
    }
}
