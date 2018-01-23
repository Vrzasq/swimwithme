using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.commons;
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
        public JsonResult GetTraining(TrainingDifficulties difficulty, int volume = 0)
        {
            TrainingCreator trainingCreator = new TrainingCreator();
            trainingCreator.SetVolume(difficulty, volume);
            Training training = trainingCreator.GetTraining();
            return Json(training);
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

