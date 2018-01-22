using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.Controllers
{
    public class TrainingTaskController : Controller
    {
        public string TestRouting()
        {
            return "hello xD";
        }

        [HttpGet]
        public JsonResult GetTraining(TrainingDifficulties difficulty, int volume)
        {
            return Json("GetTraining 2 params");
        }

        [HttpGet]
        public JsonResult GetTraining(TrainingDifficulties difficulty)
        {
            return Json("GetTraining 1 param");
        }

        [HttpGet]
        public JsonResult GetSpecyficTraining(int[] taskId)
        {
            List<int> test = new List<int>();
            for (int i = 0; i < taskId.Length; i++)
            {
                test.Add(taskId[i]);
            }

            return Json(test);
        }
    }
}

