using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.commons;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using api.repository;

namespace api.Controllers
{
    public class TrainingTaskController : Controller
    {
        private readonly ITrainingTaskRepository _ttr;

        public TrainingTaskController(ITrainingTaskRepository ttr)
        {
            _ttr = ttr;
        }

        [HttpGet]
        public string TestRouting()
        {
            return "hello xD";
        }

        [HttpGet]
        public JsonResult GetTraining(TrainingDifficulty difficulty, int volume = 0)
        {
            Trainer trainer = new Trainer(_ttr);
            Training training = trainer.MakeTraining(difficulty, volume);
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

