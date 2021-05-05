using CarePlan.Data;
using CarePlan.Models;
using CarePlan.Models.ViewModels;
using CarePlan.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarePlan.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        public IActionResult Index()
        {
            IEnumerable<RecordVM> objList = _recordService.GetRecordList();
            return View(objList);
        }
    }
}
