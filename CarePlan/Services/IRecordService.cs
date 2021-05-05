using CarePlan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarePlan.Services
{
    public interface IRecordService
    {
        public List<RecordVM> GetRecordList();

        public Task<int> AddUpdate(RecordVM model);
    }
}
