using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarePlan.Data;
using CarePlan.Models;
using CarePlan.Models.ViewModels;

namespace CarePlan.Services
{
    public class RecordService : IRecordService
    {

        private readonly ApplicationDbContext _db;

        public RecordService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<RecordVM> GetRecordList()
        {

            var records = (from record in _db.Records
                           select new RecordVM
                           {
                               RecordTitle = record.RecordTitle,
                               PatientName = record.PatientName,
                               UserName = record.UserName,
                               ActualStartDateTime = Convert.ToString(record.ActualStartDateTime),
                               TargetDateTime = Convert.ToString(record.TargetDateTime),
                               Reason = record.Reason,
                               Action = record.Action,
                               Completed = record.Completed,
                               EndDateTime = Convert.ToString(record.TargetDateTime),
                               Outcome = record.Outcome
                           }
                           ).ToList();
            return records;
        }

        public async Task<int> AddUpdate(RecordVM model)
        {
            var startDate = DateTime.Parse(model.ActualStartDateTime);
            var endDate = DateTime.Parse(model.EndDateTime);
            var targetDate = DateTime.Parse(model.TargetDateTime);

            if (model != null && model.Id > 0)
            {
                //update
                var record = _db.Records.FirstOrDefault(x => x.Id == model.Id);
                record.RecordTitle = model.RecordTitle;
                record.PatientName = model.PatientName;
                record.UserName = model.UserName;
                record.ActualStartDateTime = startDate;
                record.TargetDateTime = targetDate;
                record.Reason = model.Reason;
                record.Action = model.Action;
                record.Completed = model.Completed;
                record.EndDateTime = endDate;
                record.Outcome = model.Outcome;
                await _db.SaveChangesAsync();
                return 1;
            }
            else
            {
                //create
                Record record = new Record()
                {
                    RecordTitle = model.RecordTitle,
                    PatientName = model.PatientName,
                    UserName = model.UserName,
                    ActualStartDateTime = startDate,
                    TargetDateTime = targetDate,
                    Reason = model.Reason,
                    Action = model.Action,
                    Completed = model.Completed,
                    EndDateTime = endDate,
                    Outcome = model.Outcome
                };

                _db.Records.Add(record);
                await _db.SaveChangesAsync();
                return 2;
            }
        }

    }
}
