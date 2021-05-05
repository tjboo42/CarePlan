using CarePlan.Models.ViewModels;
using CarePlan.Services;
using CarePlan.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarePlan.Controllers.Api
{
    [Route("api/Record")]
    [ApiController]
    public class RecordAPIController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordAPIController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpPost]
        [Route("SaveRecordData")]
        public IActionResult SaveRecordData(RecordVM data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();

            //returns response in JS Notify
            try
            {
                commonResponse.status = _recordService.AddUpdate(data).Result;
                if (commonResponse.status == 1)
                {
                    commonResponse.message = Helper.recordUpdated;
                }
                if (commonResponse.status == 2)
                {
                    commonResponse.message = Helper.recordAdded;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }

            return Ok(commonResponse);
        }
    }
}
