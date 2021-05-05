using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarePlan.Models.ViewModels
{
    public class RecordVM
    {

        public int? Id { get; set; }
        public string RecordTitle { get; set; }
        public string PatientName { get; set; }
        public string UserName { get; set; }
        public string ActualStartDateTime { get; set; }
        public string TargetDateTime { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }
        public bool? Completed { get; set; }
        public string EndDateTime { get; set; }
        public string Outcome { get; set; }
    }
}
